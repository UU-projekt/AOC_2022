using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OAC2022.Day_1
{
    public class Day7 : Day<int>
    {
        override public int TestValue1
        {
            get
            {
                return 95437;
            }
        }
        override public int TestValue2
        {
            get
            {
                return 24933642;
            }
        }

        class FsFile
        {
            public string Name { get; set; }
            public int Size { get; set; }

            public FsFile(string name, int size) {
                Name = name;
                Size = size;
            }

            public override string ToString()
            {
                return $"{Name} ({Size})";
            }
        }

        class FsEntry
        {
            public int TotalSize { 
                get
                {
                    int rv = 0;
                    foreach(FsEntry e in this.Dirs.Values)
                    {
                        rv += e.TotalSize;
                    }

                    foreach(FsFile f in this.Files)
                    {
                        rv += f.Size;
                    }
;
                    return rv;
                }
            }

            public int FileSize
            {
                get
                {
                    int rv = 0;
                    foreach(var file in this.Files) rv += file.Size;
                    return rv;
                }
            }

            public string? Name { get; init; }
            public Dictionary<string, FsEntry> Dirs;
            public List<FsFile> Files;

            public FsEntry()
            {
                Dirs = new Dictionary<string, FsEntry>();
                Files = new List<FsFile>();
            }

            public void AddDir(string[] pwd, string name, FsEntry dir)
            {
                Console.WriteLine($"[AddDir] creating dir {string.Join("/", pwd)}/({name})");
                var dirRef = this.Dirs;

                foreach(string d in pwd)
                {
                    dirRef = dirRef[d].Dirs;
                }

                dirRef.Add(name, dir);
            }

            public void AddFile(string[] pwd, FsFile file)
            {
                Console.WriteLine($"[AddFile] creating file {file.Name} in {string.Join("/", pwd)}/");
                var dirRef = this;

                foreach (string d in pwd)
                {
                    dirRef = dirRef.Dirs[d];
                }

                dirRef.Files.Add(file);
            }

            public override string ToString()
            {
                string res = "";
                res += $"- {Name} (dir, size={Helpers.Colour.Text(TotalSize)})\n";

                foreach (var file in this.Files)
                {
                    res += $"   {Helpers.Colour.Text(file.Name, Helpers.Colour.Colours.Green)} (file, size={file.Size})\n";
                }

                foreach (var dir in this.Dirs.Values)
                {
                    string d = dir.ToString().Replace("\n", "\n     ");
                    res += $"   {d}\n";
                }

                return res;
            }
        }

        static FsEntry GetFileTree(string[] cmds)
        {
            List<string> pwd = new List<string>();
            FsEntry root = new FsEntry() { Name = "/" };

            foreach (var cmd in cmds)
            {
                if (cmd[0] == '$')
                {
                    var pars = cmd.Substring(2).Split(' ');

                    if (pars[0] == "cd")
                    {
                        if (pars[1] == "/") pwd.Clear();
                        else if (pars[1] == "..") pwd.RemoveAt(pwd.Count - 1);
                        else pwd.Add(pars[1]);

                        Console.WriteLine($"cd {pars[1]}");
                    }

                    if (pars[0] == "ls")
                    {
                        Console.WriteLine($"ls { string.Join("/", pwd) }: ");
                    }
                } else
                {
                    var fInf = cmd.Split(' ');

                    if (fInf[0] == "dir")
                    {
                        root.AddDir(pwd.ToArray(), fInf[1], new FsEntry() { Name = fInf[1] });
                    } else
                    {
                        root.AddFile(pwd.ToArray(), new FsFile(fInf[1], int.Parse(fInf[0])));
                    }
                }
            }

            return root;
        }

        int GetDirsUnder(FsEntry f, int thresh)
        {
            int v = 0;
            int dirSize = f.TotalSize;
            if (dirSize <= thresh) 
            {
                v += dirSize;    
            }

            if (f.Dirs.Count != 0)
            {
                foreach (FsEntry dir in f.Dirs.Values)
                {
                    v += GetDirsUnder(dir, thresh);
                }
                return v;
            }
            else return v;
        }

        int[] FlatDirs(FsEntry f)
        {
            List<int> Elegible = new List<int>();
            int dirSize = f.TotalSize;
            Elegible.Add(dirSize);

            if (f.Dirs.Count != 0)
            {
                foreach (FsEntry dir in f.Dirs.Values)
                {
                    Elegible.AddRange(FlatDirs(dir));
                }

                return Elegible.ToArray();
            }

            return Elegible.ToArray();
        }

        override public int Challange1(string[] input)
        {
            var fileTree = GetFileTree(input);

            var fileSizeUnder = GetDirsUnder(fileTree, 100000);

            Console.WriteLine(fileTree);

            return fileSizeUnder;
        }

        override public int Challange2(string[] input)
        {
            var fileTree = GetFileTree(input);

            int freeSpace = 70000000 - fileTree.TotalSize;
            int needToRemove = 30000000 - freeSpace;
            int closest = int.MaxValue;

            int[] dirs = FlatDirs(fileTree);

            foreach(int e in dirs)
            {
                if (e < needToRemove) continue;
                if (e < closest) closest = e;
            }

            Console.WriteLine($"we've {freeSpace} free. Need to clear {needToRemove}\nfound: {closest}");

            return closest;
        }
    }
}
