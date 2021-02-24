using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLab1
{
    
    public partial class Form1 : Form
    {
        private string CurentFilePass = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show(
             "Сохранить файл?",
             "Завершение программы",
             MessageBoxButtons.YesNoCancel,
             MessageBoxIcon.Warning
            );
            if (dialog == DialogResult.Yes)
            {
                SaveToolStripMenuItem_Click(sender, e);
                e.Cancel = false;
            }
            else if (dialog == DialogResult.No)
            {
                e.Cancel = false;
            }
            else e.Cancel = true;//Отменяем действие

        }
    
    private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Документ был изменен. \nСохранить изменения?", "Сохранение документа", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            switch (result)
            {
                case DialogResult.Yes: // Да - сохранить и выйти
                    {
                        SaveToolStripMenuItem_Click(sender, e);
                        textBoxInput.Text = "";
                        CurentFilePass = "";
                        break;
                    }

                case DialogResult.Cancel: // Отмена - вернуться к документу
                    {
                        return;
                    }

                case DialogResult.No: // Нет - выйти без сохранения изменений
                    {
                        textBoxInput.Text = "";
                        CurentFilePass = "";
                        break;
                    }
            }
            /*textBoxInput.Text = "";
            CurentFilePass = "";*/
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            createToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OpenToolStripMenuItem_Click(sender, e);
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "All files (*.*)|*.*|txt files (*.txt)|*.txt|python files (*.py)|*.py|cpp files (*.cpp)|*.cpp|cs files (*.cs)|*.cs";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();
                    CurentFilePass = filePath;

                    using (StreamReader reader = new StreamReader(fileStream, System.Text.Encoding.UTF8))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
            textBoxInput.Text = fileContent;

        }

        private void SaveUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = " ";
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = "c:\\";
                saveFileDialog.Filter = "All files (*.*)|*.*|txt files (*.txt)|*.txt|python files (*.py)|*.py|cpp files (*.cpp)|*.cpp|cs files (*.cs)|*.cs";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = saveFileDialog.FileName;
                }
            }
            

            string text = textBoxInput.Text;
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, false, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine(text);
                }

            }
            catch (Exception ex)
            {
                textBox2.Text = (ex.Message);
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(CurentFilePass))
            {
                string content = textBoxInput.Text;
                File.WriteAllText(CurentFilePass, content, System.Text.Encoding.UTF8);
            }

            else
            {
                SaveUsToolStripMenuItem_Click(sender, e);
            }
            }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            SaveToolStripMenuItem_Click(sender, e);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Документ был изменен. \nСохранить изменения?", "Сохранение документа", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            switch (result)
            {
                case DialogResult.Yes: // Да - сохранить и выйти
                    {
                        SaveToolStripMenuItem_Click(sender, e);
                        Close();
                        break;
                    }

                case DialogResult.Cancel: // Отмена - вернуться к документу
                    {
                        return;
                    }

                case DialogResult.No: // Нет - выйти без сохранения изменений
                    {
                        Close();
                        break;
                    }
            }
        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxInput.Undo();
        }

        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxInput.Redo();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            UndoToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            RedoToolStripMenuItem_Click(sender, e);
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxInput.SelectedText = "";
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxInput.Cut();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxInput.Copy();
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxInput.Paste();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            CopyToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            CutToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            PasteToolStripMenuItem_Click(sender, e);
        }

        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxInput.SelectAll();
        }

        private void SummonHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help newForm = new Help();
            newForm.Show();
        }

        private void AboutTheProgrammToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutTheProgramm newForm = new AboutTheProgramm();
            newForm.Show();
        }

  
    }
}
