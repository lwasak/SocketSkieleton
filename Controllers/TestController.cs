using Microsoft.AspNetCore.Mvc;
using SocketSkeleton.Dto;

namespace SocketSkeleton.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    public TestResponse Get()
    {
        return new TestResponse(1, "Typtypeki");
    }
}