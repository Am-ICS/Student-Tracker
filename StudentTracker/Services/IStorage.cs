using StudentTracker.Models;

namespace StudentTracker.Services;

public interface IStorage
{
    public Task<List<TaskStudent>> LoadAsync();
    public Task Save(List<TaskStudent> tasks);
}