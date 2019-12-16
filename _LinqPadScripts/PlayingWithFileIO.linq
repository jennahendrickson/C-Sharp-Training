<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.dll</Reference>
</Query>

public string DefaultPath { get { return @"C:\Users\vwt482\source\GitHub-Csharp\_LinqPadScripts"; } }
public string DefaultFile { get { return @"C:\Users\vwt482\source\GitHub-Csharp\_LinqPadScripts\testImport.txt"; } }

void Main()
{
	//	var files = GetFilesInDirectory();
	//	files.ForEach(x => { ReadFileOption3(x.FullName).Dump(); });
	//	WriteFileOption1(new List<string>() {"hello", "world"});
	//	WriteFileOption2("this");
	//	WriteFileOption3("is");
	//	WriteFileOption4(new List<string>() {"really", "silly"});
	//	WriteFileOption5("stuff");

	//	var outputFile = Path.Combine(new FileInfo(DefaultFile).DirectoryName, "copiedFile.txt");
	//	File.Copy(DefaultFile, outputFile);

	//	Path.Combine("a", "b", "c", "d").Dump();

	var outputFile = Path.Combine(new FileInfo(DefaultFile).DirectoryName, "copiedFile.txt");
	File.Move(DefaultFile, outputFile);
}

private List<FileInfo> GetFilesInDirectory()
{
	//DateTime.Today.AddMinutes(-1).Dump();
	var dir = new DirectoryInfo(DefaultPath);
	var files = dir.GetFiles();
	//	.Where(x => x.CreationTime >= DateTime.Now.AddMinutes(-100))
	//	.OrderBy(x => new { x.Name, x.CreationTime });
	// GC.Collect(); 
	//	files.Dump();
	return files.ToList();
}

private void CreateDirectory()
{
	if (!Directory.Exists(DefaultPath))
	{
		Directory.CreateDirectory(DefaultPath);
	}
}

private string ReadFileOption1(string filePath)
{
	return File.ReadAllText(filePath);
}

private List<string> ReadFileOption2(string filePath)
{
	return File.ReadAllLines(filePath).ToList();
}

private string ReadFileOption3(string filePath)
{
	var stream = new System.IO.StreamReader(filePath);
	var results = new StringBuilder();
	var line = string.Empty;
	while ((line = stream.ReadLine()) != null)
	{
		results.AppendLine(line);
	}
	return results.ToString();
}

private void WriteFileOption1(List<string> contents)
{
	File.WriteAllLines(DefaultFile, contents);
}

private void WriteFileOption2(string contents)
{
	File.WriteAllText(DefaultFile, contents);
}

private void WriteFileOption3(string contents)
{
	File.AppendAllText(DefaultFile, contents);
}

private void WriteFileOption4(List<string> contents)
{
	File.AppendAllLines(DefaultFile, contents);
}

private void WriteFileOption5(string contents)
{
	using (StreamWriter sw = File.AppendText(DefaultFile))
	{
		sw.WriteLine(contents);
	}
}