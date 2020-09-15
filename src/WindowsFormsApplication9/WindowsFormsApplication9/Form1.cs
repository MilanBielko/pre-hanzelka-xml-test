using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
            XMLSpyLib.Application XMLSpy;
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse xml Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "xml",
                Filter = "xml files (*.xml)|*.xml",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                button1.Text = "Waiting for open file";
                if (XMLSpy == null)
                {

                    Cursor.Current = Cursors.WaitCursor;

                    XMLSpy = new XMLSpyLib.Application();

                    XMLSpy.Visible = true;

                    Cursor.Current = Cursors.Default;

                }

                else
                {


                    if (!XMLSpy.Visible)

                        XMLSpy.Visible = true;

                }
    
                XMLSpy.Documents.OpenFile(@openFileDialog1.FileName , false);
                button1.Text  = "Open xml file to xml spy";
            }  
            
        }
    }
}
