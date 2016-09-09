using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace FileScanner
{
    public partial class Form1 : Form
    {
        StreamWriter fileWriter;
        String currentDir;
        String htmlPath = "/index.html";
        String header = "Files explorer";

        public Form1()
        {
            InitializeComponent();

            currentDir = Directory.GetCurrentDirectory();
            htmlPath = currentDir + htmlPath;
        }

        private void scanner(DirectoryInfo di, int layers)
        {
            if (layers == 0)
            {
                return;
            }

            bool hasFile = false;

            IEnumerator files = di.EnumerateFiles().GetEnumerator();
            while (files.MoveNext())
            {
                fileWriter.WriteLine("<ul style=\"list-style-type:none\">");
                if (!((FileInfo)files.Current).Attributes.HasFlag(FileAttributes.Hidden))
                {
                    fileWriter.WriteLine("<li><a href = \"file:///" + di.FullName + "\\" + files.Current + "\" >"+files.Current + "</a></li>");
                    hasFile = true;
                }
                fileWriter.WriteLine("</ul>");
            }

            if (!hasFile)
            {
                //fileWriter.WriteLine("<br> ### no file in this directory ###");
            }

            IEnumerator folders = di.EnumerateDirectories().GetEnumerator();
            while (folders.MoveNext())
            {
                if (!((DirectoryInfo)folders.Current).Attributes.HasFlag(FileAttributes.Hidden))
                {
                    fileWriter.WriteLine("<ol style=\"list-style-type:none\">");
                    fileWriter.WriteLine("<li><H2><a href = \"file:///" + di.FullName + "\\" + folders.Current + "\" >" + folders.Current + "</a></H2></li>");
                    fileWriter.WriteLine();
                    scanner((DirectoryInfo)folders.Current, layers-1);
                    fileWriter.WriteLine("</ol>");
                }
            }
        }

        private void generateFile()
        {
            fileWriter = new StreamWriter(htmlPath, false);
            
            fileWriter.WriteLine("<html>\n<head>\n<meta charset=\"UTF-8\">\n<title>"
                +header+ "</title><link rel=\"stylesheet\" href=\"wiki\\sources\\_html_sources\\style.css\" type=\"text/css\">\n</head>");
            fileWriter.WriteLine("<body>");

            string ul = "ul{ margin-left:0.4em; } ol{ margin-left:0.4em; }";
            fileWriter.WriteLine("<style>");
            fileWriter.WriteLine(ul);
            fileWriter.WriteLine("ul li{font-size:14px; font-family: Geneva, Lucida Grande, Univers, Helvetica, sans-serif;font-variant: normal;text-align: justify; color: #323232;}");
            fileWriter.WriteLine("ul li:before{content: '\\2192';margin: 1em 1em;} H2:before{content: '\\25A0';margin: 1em 1.4em;}</style> ");
        }

        private void btn_scan_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(currentDir);
            int layers_toScan = (int)nud_layer.Value;
            if (layers_toScan == 0)
            {
                layers_toScan = -1;
            }

            generateFile();
            scanner(di, layers_toScan);
            fileWriter.WriteLine("\n</body>\n</html>");
            fileWriter.Flush();
            fileWriter.Close();
            MessageBox.Show("An html file 'index.html' has been generated and saved in current directory", "Success!", MessageBoxButtons.OK);
        }

        private void btn_about_Click(object sender, EventArgs e)
        {
            String title = "About";
            String text = "This tool is used to get an overview of files in a directory. "+
                "Simply place this tool in the directory you want to scan.";
            MessageBox.Show(text, title, MessageBoxButtons.OK);
        }
    }
}
