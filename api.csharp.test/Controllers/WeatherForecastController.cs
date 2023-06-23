using Microsoft.AspNetCore.Mvc;

namespace api.csharp.test.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}

[ApiController]
[Route("[controller]/[action]")]
public class talk:ControllerBase
{
    [HttpGet(Name = "hello1")] // 标识符每个唯一，不一定和方法名相同
    public string hello() // 传递路由
    {
        return "talk 1!";
    }

    [HttpGet(Name = "hello2")]
    public string hello2() // 传递路由
    {
        return "talk 2!";
    }
}

[ApiController]
[Route("[controller]/[action]")]
public class fruit : ControllerBase
{
    [HttpGet(Name = "apple")] // 标识符每个唯一，不一定和方法名相同
    public string apple() // 传递路由
    {
        return "Get Apple!";
    }

    [HttpGet(Name = "bnana")]
    public string bnana() // 传递路由
    {
        return "Get Bnana!";
    }
}

[ApiController]
[Route("[controller]/[action]")]
public class calc : ControllerBase
{
    [HttpGet("{number}")]
    public string num(int number)
    {
        return $"Number {number}!";
    }

    [HttpGet("{num1}/{num2}")]
    public string add(int num1, int num2)
    {
        return $"Sum: {num1 + num2}!";
    }

    [HttpGet]
    public string add2(int num1, int num2)
    {
        return $"Sum: {num1 + num2}!";
    }
}

[ApiController]
[Route("[controller]/[action]")]
public class user : ControllerBase
{
    [HttpGet("{uid}")]
    public string query(int uid)
    {
        return $"query userId: {uid}!";
    }

    [HttpGet("{uid}/add/{value}", Name = "qwer")]
    public string recharge(int uid, int value)
    {
        return $"userId: {uid} recharged {value} successfully!";
    }

    [HttpPost("/user/{uid}/edit")] // 以/开头改变默认的path顺序，如果没有/开头，直接{uid}=>edit/{uid}
    public Response.UserEditRet edit(int uid, [FromBody] Request.UserEdit req)
    {
        var ret = new Response.UserEditRet
        {
            status = 200,
            msg = $"userId: {uid} edited successfully!",
        };

        var userInfo = new Request.UserEdit { };
        userInfo.name = req.name;
        userInfo.address = req.address;
        var data = new List<Request.UserEdit> { };
        data.Add(userInfo);
        ret.data = data;
        return ret;
    }

[HttpGet("all")]
    public string list()
    {
        return "[{user1}, {user2}, {user3}]";
    }
}

[ApiController]
[Route("[controller]/[action]")]
public class test : ControllerBase
{
    [HttpGet]
    public string index() {
        return $"{1}";
    }
}