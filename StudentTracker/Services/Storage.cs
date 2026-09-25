
using Newtonsoft.Json;
using StudentTracker.Models;
using System.IO;

namespace StudentTracker.Services;
public static class Storage
{
  private static readonly string filename = "student.json";
  // private static readonly string filePath = Path.Combine(FileSystem.AppDataDirectory, filename); 
   public static string filePath;

  public static void Init(string directory)
  {
    filePath = Path.Combine(directory, filename);
  }

  private static readonly JsonSerializerSettings settings = new JsonSerializerSettings
  {
      TypeNameHandling = TypeNameHandling.All, 
      Formatting = Formatting.Indented
  };


  public static async Task<List<TaskStudent>> LoadAsync()
  {

    if (!File.Exists(filePath))
    {
       return new List<TaskStudent>(); 
    }

    StreamReader reader =  new StreamReader(filePath);

    string JsonData = reader.ReadToEnd();

    reader.Close();

    List<TaskStudent> tasks = JsonConvert.DeserializeObject<List<TaskStudent>>(JsonData, settings);

  
    return tasks;
  }

  public static async Task Save(List<TaskStudent> tasks)
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