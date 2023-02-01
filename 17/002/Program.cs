
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

//运行基准测试
BenchmarkRunner.Run<PgoBenchmarks>();

[Config(typeof(MyEnvVars))]
public class PgoBenchmarks
{
    // 自定义配置环境 "Default vs DPGO"
    class MyEnvVars : ManualConfig
    {
        public MyEnvVars()
        {
            // 使用默认模式
            AddJob(Job.Default.WithId("Default mode"));
            // 使用DPGO模式模式
            AddJob(Job.Default.WithId("Dynamic PGO")
                .WithEnvironmentVariables(
                    new EnvironmentVariable("DOTNET_TieredPGO", "1"),
                    new EnvironmentVariable("DOTNET_TC_QuickJitForLoops", "1"),
                    new EnvironmentVariable("DOTNET_ReadyToRun", "0")));

        }
    }

    [Benchmark]
    [Arguments(6, 100)]
    public int HotColdBasicBlockReorder(int key, int data)
    {
        if (key == 1)
            return data - 5;
        if (key == 2)
            return data += 4;
        if (key == 3)
            return data >> 3;
        if (key == 4)
            return data * 2;
        if (key == 5)
            return data / 1;
        return data; // 默认key为6，所以会使用返回data 
    }
}

