
using Newtonsoft.Json;
using StudentTracker.Models;
using System.IO;

namespace StudentTracker.Services;
public class Storage : IStorage
{
  private JsonSerializerSettings settings;
  private string filePath;
  
  
  // private static readonly string filePath = Path.Combine(FileSystem.AppDataDirectory, filename); 

  public Storage(string directory, string filename, JsonSerializerSettings settings)
  {
    filePath = Path.Combine(directory, filename);
    Console.WriteLine(Path.GetFullPath(Path.Combine(directory, filename)));
    //throw new Exception(Path.GetFullPath(Path.Combine(directory, filename)));
    this.settings = settings;
  }

  public Storage(string directory, string filename) :
    this(directory, filename, defaultSetting)
  {
    
  }
  

  private static readonly JsonSerializerSettings defaultSetting = new JsonSerializerSettings
  {
      TypeNameHandling = TypeNameHandling.All, 
      Formatting = Formatting.Indented
  };


  public async Task<List<TaskStudent>> LoadAsync()
  {

    if (!File.Exists(filePath))
    {
       return new List<TaskStudent>(); 
    }

    StreamReader reader =  new StreamReader(filePath);

    string JsonData = await reader.ReadToEndAsync();

    reader.Close();

    List<TaskStudent> tasks = JsonConvert.DeserializeObject<List<TaskStudent>>(JsonData, settings);

  
    return tasks;
  }

  public async Task Save(List<TaskStudent> tasks)
  {

    if(tasks.Count == 0)
        return ; 

    StreamWriter writer = new StreamWriter(filePath);
    
    string json = JsonConvert.SerializeObject(tasks, settings);
    
    await writer.WriteAsync(json);
    await writer.FlushAsync();

    writer.Close();
  }
}