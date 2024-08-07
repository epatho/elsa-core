using Elsa.WorkflowContexts.Abstractions;
using Elsa.Workflows;

namespace ExpServer.WorkflowCtxProvider;

public class TestWfCtxProvider : WorkflowContextProvider<DataStage>
{
    protected override async ValueTask<DataStage?> LoadAsync(WorkflowExecutionContext workflowExecutionContext)
    {
        //var customerId = workflowExecutionContext.GetWorkflowContextParameter<TestWfCtxProvider, string>();
        await Task.Delay(100);
        return new DataStage(1000, "TestStage");
    }

    protected override async ValueTask SaveAsync(WorkflowExecutionContext workflowExecutionContext, DataStage? context)
    {
        if (context != null)
        {
            await Task.Delay(100);
        }
    }
}

public class DataStage(int id, string name)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;

    public List<Item> Items { get; set; } =
    [
        new Item {Id = 1, Name = "Alma"},
        new Item {Id = 2, Name = "Körte"},
        new Item {Id = 3, Name = "Barack"}
    ];
}

public class Item
{
    public int Id { get; set; }

    public string? Name { get; set; }
}