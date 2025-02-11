
using System.Net;
using Alba;

namespace Todos.Tests.Todos;
public class GettingTodos
{
    [Fact]
    public async Task GetsAOkStatusCode()
    {
        var host = await AlbaHost.For<Program>();

        await host.Scenario(api =>
        {
            api.Get.Url("/todos");
            api.StatusCodeShouldBeOk(); // 200
        });
    }
}
