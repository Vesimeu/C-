using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ByteFrequencyApp
{
    public partial class Form1 : Form
    {
        private DataGridView dataGridView;
        private Label titleLabel;

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            this.Text = "Byte Frequency Analyzer";
            this.Width = 800;
            this.Height = 600;

            var menuStrip = new MenuStrip();
            var fileMenu = new ToolStripMenuItem("File");
            var openMenuItem = new ToolStripMenuItem("Open", null, new EventHandler(OpenFile));
            fileMenu.DropDownItems.Add(openMenuItem);
            menuStrip.Items.Add(fileMenu);
            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);

            titleLabel = new Label
            {
                Text = "Byte Frequency Analyzer",
                Location = new System.Drawing.Point((this.ClientSize.Width - 200) / 2, 20),
                Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold),
                AutoSize = true
            };
            this.Controls.Add(titleLabel);

            dataGridView = new DataGridView
                {
                    Top = titleLabel.Bottom + 20,
                    Left = 20,
                    Width = this.ClientSize.Width - 40, // Ширина таблицы равна ширине формы с учетом отступов по 20 пикселей с каждой стороны
                    Height = this.ClientSize.Height - titleLabel.Bottom - 80, // Высота таблицы рассчитывается так, чтобы оставить место для элементов под ней
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                    ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                    AllowUserToAddRows = false,
                    ReadOnly = true
                };

            dataGridView.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "ByteValue", HeaderText = "Byte Value", DataPropertyName = "ByteValue" },
                new DataGridViewTextBoxColumn { Name = "Count", HeaderText = "Count", DataPropertyName = "Count" });

            this.Controls.Add(dataGridView);
        }

        private void OpenFile(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All Files|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = openFileDialog.FileName;
                    var byteCounts = GetByteFrequency(filePath);
                    DisplayByteFrequency(byteCounts);
                }
            }
        }

        private Dictionary<byte, int> GetByteFrequency(string filePath)
        {
            var byteCounts = new Dictionary<byte, int>();

            foreach (var b in File.ReadAllBytes(filePath))
            {
                if (byteCounts.ContainsKey(b))
                {
                    byteCounts[b]++;
                }
                else
                {
                    byteCounts[b] = 1;
                }
            }

            return byteCounts;
        }

        private void DisplayByteFrequency(Dictionary<byte, int> byteCounts)
        {
            dataGridView.Rows.Clear();

            foreach (var kvp in byteCounts.OrderBy(kvp => kvp.Key))
            {
                dataGridView.Rows.Add(kvp.Key, kvp.Value);
            }
        }
    }
}
