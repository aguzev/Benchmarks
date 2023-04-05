``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.2728/22H2/2022Update)
Intel Core i5-6600K CPU 3.50GHz (Skylake), 1 CPU, 4 logical and 4 physical cores
.NET SDK=8.0.100-preview.1.23115.2
  [Host]               : .NET 7.0.4 (7.0.423.11508), X64 RyuJIT AVX2
  .NET 7.0             : .NET 7.0.4 (7.0.423.11508), X64 RyuJIT AVX2
  .NET Framework 4.6.2 : .NET Framework 4.8 (4.8.4614.0), X64 RyuJIT VectorSize=256


```
|    Method |                  Job |              Runtime | Categories |      Mean |    Error |   StdDev | Ratio |
|---------- |--------------------- |--------------------- |----------- |----------:|---------:|---------:|------:|
|  concat_n |             .NET 7.0 |             .NET 7.0 |      Int32 |  17.75 ms | 0.070 ms | 0.065 ms |  0.92 |
| foreach_n |             .NET 7.0 |             .NET 7.0 |      Int32 |  19.25 ms | 0.069 ms | 0.065 ms |  1.00 |
|           |                      |                      |            |           |          |          |       |
|  concat_n | .NET Framework 4.6.2 | .NET Framework 4.6.2 |      Int32 |  21.73 ms | 0.087 ms | 0.081 ms |  0.97 |
| foreach_n | .NET Framework 4.6.2 | .NET Framework 4.6.2 |      Int32 |  22.45 ms | 0.099 ms | 0.093 ms |  1.00 |
|           |                      |                      |            |           |          |          |       |
|  concat_o |             .NET 7.0 |             .NET 7.0 |     Object |  17.70 ms | 0.101 ms | 0.095 ms |  0.92 |
| foreach_o |             .NET 7.0 |             .NET 7.0 |     Object |  19.27 ms | 0.105 ms | 0.098 ms |  1.00 |
|           |                      |                      |            |           |          |          |       |
|  concat_o | .NET Framework 4.6.2 | .NET Framework 4.6.2 |     Object |  21.73 ms | 0.084 ms | 0.078 ms |  0.97 |
| foreach_o | .NET Framework 4.6.2 | .NET Framework 4.6.2 |     Object |  22.46 ms | 0.090 ms | 0.084 ms |  1.00 |
|           |                      |                      |            |           |          |          |       |
|  concat_s |             .NET 7.0 |             .NET 7.0 |     String |  28.50 ms | 0.103 ms | 0.097 ms |  0.89 |
| foreach_s |             .NET 7.0 |             .NET 7.0 |     String |  32.05 ms | 0.155 ms | 0.145 ms |  1.00 |
|           |                      |                      |            |           |          |          |       |
|  concat_s | .NET Framework 4.6.2 | .NET Framework 4.6.2 |     String | 119.45 ms | 0.925 ms | 0.866 ms |  1.01 |
| foreach_s | .NET Framework 4.6.2 | .NET Framework 4.6.2 |     String | 118.02 ms | 0.371 ms | 0.347 ms |  1.00 |
