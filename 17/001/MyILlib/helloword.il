//包括了当前程序集运行所需的外部程序集（System.Runtime.dll）
.assembly extern System.Runtime
{
    .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )
    .ver 4:0:0:0
}

.assembly MyILlib
{
  .ver 1:0:0:0
}
 
.module MyILlib.dll

.class public auto ansi beforefieldinit Hello
  extends [System.Runtime]System.Object
{
  .method public hidebysig static string World() cil managed
  {
    .maxstack 8
    ldstr   "Hello World!"
    ret
  }
}

