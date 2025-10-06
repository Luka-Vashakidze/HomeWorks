using System;

namespace homework10
{
    public abstract class FileWorker
    {
        public abstract string FileExtension { get; }
        public int MaxSize { get; set; }

        public abstract void Read();
        public abstract void Write();
        public abstract void Edit();
        public abstract void Delete();
    }

    public class FileWorkerChild : FileWorker
    {
        private readonly string _fileExtension;

        public FileWorkerChild(string fileExtension, int maxSize)
        {
            _fileExtension = fileExtension;
            this.MaxSize = maxSize;
        }

        public override string FileExtension => _fileExtension;

        public override void Read()
        {
            Console.WriteLine($"I can read from {FileExtension} file with max storage {MaxSize}");
        }

        public override void Write()
        {
            Console.WriteLine($"I can write to {FileExtension} file with max storage {MaxSize}");
        }

        public override void Edit()
        {
            Console.WriteLine($"I can edit {FileExtension} file with max storage {MaxSize}");
        }

        public override void Delete()
        {
            Console.WriteLine($"I can delete from  {FileExtension} file with max storage {MaxSize}");
        }
    }
}