// See https://aka.ms/new-console-template for more information
using System.IO.Compression;
using System.Text;
using ZipFile.Models;
var files =  new InMemoryFile[] 
{
    O.LoadFromFile(@"D:\temp\gpc.report2022.10.05.log"),
    O.LoadFromFile(@"D:\temp\TC624070.pdf"),
};
            
var bytes = O.GetZipArchive(files);
 


  //  new InMemoryFile{FileName = @"\pasta1\texte.txt", FolderName = "pasta1",  Content = Encoding.ASCII.GetBytes("texte.txt")},    
    //new InMemoryFile{FileName = @"\pasta2\texte22.txt", FolderName = "pasta2", Content = Encoding.ASCII.GetBytes("texte22.txt")}

 

File.WriteAllBytes(@"D:\temp\teste.zip", bytes);


Console.WriteLine("Hello, World!");