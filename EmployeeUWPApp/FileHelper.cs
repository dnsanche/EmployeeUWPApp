using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace EmployeeUWPApp
{
    static class FileHelper
    {
        //Create a file
        public async static void WriteTextFileAsync(
            string filename, string content)
        {
            var storageFolder = ApplicationData.Current.LocalFolder;
            var textFile = await storageFolder.CreateFileAsync(filename, CreationCollisionOption.OpenIfExists); //In this case, everytime you have Async, you need to write await.

            //Open File, Write Content, Close the file
            var textStream = await textFile.OpenAsync(FileAccessMode.ReadWrite);
            var textWriter = new DataWriter(textStream);
            textWriter.WriteString(content);
            await textWriter.StoreAsync();
        }
        //Read method to read from the file
        public static async Task<string> ReadTextFileAsync(string filename)
            //Task is the thread that does the work and comes back
        {
            //Get access to the file
            var storageFolder = ApplicationData.Current.LocalFolder;
            //Get the file
            var textFile = await storageFolder.GetFileAsync(filename);
            //Open the file and read it
            var textStream = await textFile.OpenAsync(FileAccessMode.ReadWrite);
            var textReader = new DataReader(textStream);
            var textLength = textStream.Size;
            await textReader.LoadAsync((uint)textLength);
            return textReader.ReadString((uint)textLength);
        }



    }
}
