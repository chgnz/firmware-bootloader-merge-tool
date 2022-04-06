using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace gbox_ll_merge
{
    public partial class mapon_fw_merge : Form
    {

        string bootloader_location = null;
        string firmware_location = null;
        string output_location = null;

        const string maponRegistryAddress = @"Software\Mapon\Merger";

#if MCU_NXP_LPC1768
        private IFwDescriptor descriptor = new LPC1768_Descriptor();
#elif MCU_STM32H7
        private IFwDescriptor descriptor = new STM32H7_Descriptor();
#endif

        public mapon_fw_merge()
        {                      
            InitializeComponent();
            this.Text  += $" ({descriptor.GetMcuName()})";
        }

        private void INFO(string error_str, Color c)
        {
            Debug.WriteLine(error_str);
            Console.WriteLine(error_str);
            tssbl_error.Text = error_str;
            tssbl_error.ForeColor = c;
        }

        private void save_path_in_register(string name, string value)
        {
            Microsoft.Win32.RegistryKey key;

            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(maponRegistryAddress);
            key.SetValue(name, value);
        }

        private void load_path_from_register()
        {
            try
            {
                Microsoft.Win32.RegistryKey key;
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(maponRegistryAddress);

                foreach (string SubKeyName in key.GetValueNames())
                {
                    switch (SubKeyName)
                    {
                        case "Bootloader_Location":
                            bootloader_location = key.GetValue(SubKeyName).ToString();
                            tb_bootloader_location.Text = key.GetValue(SubKeyName).ToString();
                            break;
                        case "Firmware_Location":
                            firmware_location = key.GetValue(SubKeyName).ToString();
                            tb_firmware_location.Text = key.GetValue(SubKeyName).ToString();
                            break;
                        case "Output_Location":
                            output_location = key.GetValue(SubKeyName).ToString();
                            tb_output_location.Text = key.GetValue(SubKeyName).ToString();
                            break;
                        default: break;
                    }
                }
            }
            catch { }
        }


        bool validate_filesize(string path, int max_size)
        {
            if (File.Exists(path))
            {
                long length = new FileInfo(path).Length;
                if (length < max_size)
                    return true;
            }
            return false;
        }

        private string open_file()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Debug.WriteLine(ofd.FileName);
                return ofd.FileName;
            }

            return null;
        }

        private string save_file()
        {
            SaveFileDialog sfd = new SaveFileDialog();

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Debug.WriteLine(sfd.FileName);
                return sfd.FileName;
            }

            return null;
        }

        private void b_set_bootloader_location_Click(object sender, EventArgs e)
        {
            string result = open_file();
            if (result != null)
            {
                bootloader_location = result;
                tb_bootloader_location.Text = result;
                save_path_in_register("Bootloader_Location", bootloader_location);
                if (!validate_filesize(result, descriptor.GetBootloaderMaxSize()))
                {
                    INFO($"WARNING, Bootloader exceeds {descriptor.GetBootloaderMaxSize()} bytes", Color.OrangeRed);
                }
            }
        }
        
        private void b_set_firmware_location_Click(object sender, EventArgs e)
        {
            string result = open_file();
            if (result != null)
            {
                firmware_location = result;
                tb_firmware_location.Text = result;
                save_path_in_register("Firmware_Location", firmware_location);

                if (!validate_filesize(result, descriptor.GetFirmwareFileMaxSize()))
                {
                    INFO("WARNING, Firmware exceeds " + (descriptor.GetFirmwareFileMaxSize()) / 1024 + " Kb", Color.OrangeRed);
                }
            }
        }

        private void b_output_location_Click(object sender, EventArgs e)
        {
            string result = save_file();
            if (result != null)
            {
                output_location = result;
                tb_output_location.Text = result;
                save_path_in_register("Output_Location", output_location);
            }
        }

        public bool create_output_file(string bootloader_location, string firmware_location, string output_location)
        {
            if (!File.Exists(bootloader_location) || !File.Exists(firmware_location))
            {
                if(!File.Exists(bootloader_location))
                    INFO("Bootloader file doesnt exists",Color.Red);
                else
                    INFO("Firmware file doesnt exists", Color.Red);

                return false;
            }

            if (!validate_filesize(bootloader_location, descriptor.GetBootloaderMaxSize()))
            {
                INFO("Incorrect bootloader filesize", Color.Red);
                return false;
            }

            if (!validate_filesize(firmware_location, descriptor.GetFirmwareFileMaxSize()))
            {
                INFO("Incorrect firmware filesize", Color.Red);
                return false;
            }

            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(output_location, FileMode.Create)))
                {
                    long bootloader_real_size = new FileInfo(bootloader_location).Length;
                    using (BinaryReader reader = new BinaryReader(File.Open(bootloader_location, FileMode.Open)))
                    {
                        // parkopējam bootlaoder saturu
                        writer.Write(reader.ReadBytes((int)bootloader_real_size));
                    }

                    // izveidojam nepiciešamā izmēra bufferi un aizpildam ar 0xFF
                    int buffer_size = descriptor.GetBootloaderMaxSize() - (int)bootloader_real_size;
                    byte[] bootloader_buffer = new byte[buffer_size];
                    for (int i = 0; i < buffer_size; i++)
                    {
                        bootloader_buffer[i] = 0xFF;
                    }

                    // ierakstam.
                    writer.Write(bootloader_buffer);


                    long firmware_real_size = new FileInfo(firmware_location).Length;
                    using (BinaryReader reader = new BinaryReader(File.Open(firmware_location, FileMode.Open)))
                    {
                        // parkopējam bootlaoder saturu
                        writer.Write(reader.ReadBytes((int)firmware_real_size));
                    }

                    // izveidojam nepiciešamā izmēra bufferi un aizpildam ar 0xFF
                    buffer_size = descriptor.GetFirmwareFileMaxSize() - (int)firmware_real_size;
                    byte[] fw_buffer = new byte[buffer_size];
                    for (int i = 0; i < buffer_size; i++)
                    {
                        fw_buffer[i] = 0xFF;
                    }

                    // ierakstam.
                    writer.Write(fw_buffer);
                }

                INFO("Done. Created " + output_location + " file", Color.Green);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void b_merge_Click(object sender, EventArgs e)
        {
            create_output_file(tb_bootloader_location.Text, tb_firmware_location.Text, tb_output_location.Text);
        }

        private void mapon_fw_merge_Load(object sender, EventArgs e)
        {
            load_path_from_register();
        }
    }
}
