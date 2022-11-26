using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static System.Console;

namespace StntaxAnalyzer.SyntaxWalker;

public class UsingCollector : CSharpSyntaxWalker
{
    public ICollection<UsingDirectiveSyntax> Usings { get; } = new List<UsingDirectiveSyntax>();

    public override void VisitUsingDirective(UsingDirectiveSyntax node)
    {
        WriteLine($"\tVisit Using Directive called with {node.Name}.");
        if (node.Name.ToString() == "System" ||
            node.Name.ToString().StartsWith("System.")) return;
        WriteLine($"\t\tSuccess. Adding {node.Name}."); 
        Usings.Add(node);
    }
}
