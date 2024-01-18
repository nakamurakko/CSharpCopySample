using System.Text.Json;

namespace CSharpCopySample;

class SampleClass
{
    public object PropertyA { get; set; } = new object();

    /// <summary>
    /// Shallow copy。
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Object.MemberwiseClone Method の Example を参考にした。
    /// <see href="https://learn.microsoft.com/en-us/dotnet/api/system.object.memberwiseclone?view=net-8.0#examples"/>
    /// </remarks>
    public SampleClass ShallowCopy()
    {
        return (SampleClass)this.MemberwiseClone();
    }

    /// <summary>
    /// Deep copy。
    /// </summary>
    /// <returns></returns>
    public SampleClass DeepCopy()
    {
        return JsonSerializer.Deserialize<SampleClass>(JsonSerializer.Serialize(this));
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        SampleClass sample = new SampleClass();

        Console.WriteLine("サンプル1 参照渡し");
        SampleClass sample1 = sample;
        Console.WriteLine($@"sample.Equals(sample1) : {sample.Equals(sample1)}");
        Console.WriteLine($@"sample.PropertyA.Equals(sample1.PropertyA) : {sample.PropertyA.Equals(sample1.PropertyA)}");

        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("サンプル2 Object.MemberwiseClone() による shallow copy");
        SampleClass sample2 = sample.ShallowCopy();
        Console.WriteLine($@"sample.Equals(sample2) : {sample.Equals(sample2)}");
        Console.WriteLine($@"sample.PropertyA.Equals(sample2.PropertyA) : {sample.PropertyA.Equals(sample2.PropertyA)}");

        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("サンプル3 JSON シリアライズ → デシリアライズによる deep copy");
        SampleClass sample3 = sample.DeepCopy();
        Console.WriteLine($@"sample.Equals(sample3) : {sample.Equals(sample3)}");
        Console.WriteLine($@"sample.PropertyA.Equals(sample3.PropertyA) : {sample.PropertyA.Equals(sample3.PropertyA)}");
    }
}
