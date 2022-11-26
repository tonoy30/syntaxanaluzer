using Microsoft.CodeAnalysis.CSharp;
using StntaxAnalyzer.SyntaxWalker;
using static System.Console;

const string programText =
    @"using System;
    using System.Collections;
    using System.Linq;
    using System.Text;

    namespace HelloWorld
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(""Hello, World!"");
            }
        }
    }";

var tree = CSharpSyntaxTree.ParseText(programText);
var root = tree.GetCompilationUnitRoot();

var collector = new UsingCollector();
collector.Visit(root);

foreach (var directive in collector.Usings)
{
    WriteLine(directive.Name);
}