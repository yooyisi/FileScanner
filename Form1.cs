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
        String title = "Files in current directory: ";

        public Form1()
        {
            InitializeComponent();

            currentDir = Directory.GetCurrentDirectory();
            htmlPath = currentDir + htmlPath;
            title = title + currentDir;
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
                if (!((FileInfo)files.Current).Attributes.HasFlag(FileAttributes.Hidden))
                {
                    fileWriter.WriteLine("<li><a href = \"file:///" + di.FullName + "\\" + files.Current + "\" >" + files.Current + "</a></li>");
                    hasFile = true;
                }
            }

            if (!hasFile)
            {
                fileWriter.WriteLine("<br> ### no file in this directory ###");
            }

            IEnumerator folders = di.EnumerateDirectories().GetEnumerator();
            while (folders.MoveNext())
            {
                if (!((DirectoryInfo)folders.Current).Attributes.HasFlag(FileAttributes.Hidden))
                {
                    fileWriter.WriteLine("<ul>");
                    fileWriter.WriteLine("----------------------------");
                    fileWriter.WriteLine("<a href = \"file:///" + di.FullName + "\\" + folders.Current + "\" >" + folders.Current + "</a>");
                    fileWriter.WriteLine("----------------------------");
                    fileWriter.WriteLine();
                    scanner((DirectoryInfo)folders.Current, layers-1);
                    fileWriter.WriteLine("</ul>");
                }
            }
        }

        private void generateFile()
        {
            fileWriter = new StreamWriter(htmlPath, false);
            
            fileWriter.WriteLine("<html>\n<head>\n<meta charset=\"UTF-8\">\n<title>"
                +header+"</title>\n</head>");
            fileWriter.WriteLine("<body>");
            fileWriter.WriteLine("<h1>"+ title +"</h1>");
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
