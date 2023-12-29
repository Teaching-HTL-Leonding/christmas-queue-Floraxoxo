using System.Diagnostics.Metrics;
using System.Net.Mime;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;

namespace ChristmasQueue.Collections;

/// Represents a node in a stack, holding the content and a reference to the next node.

/// Note that the class is "internal". That means that it is only visible inside the
/// project. Other projects cannot access it.
internal class StackNode
{
    /// Gets the content of the stack node.
    public string Content { get; }

    /// Gets or sets the next node in the stack.
    public StackNode? Next { get; set; }

    /// Initializes a new instance of the StackNode class with the specified content.

    /// <param name="content">The content to store in the node.</param>
    public StackNode(string content)
    {
        Content = content;
    }
}

/// Represents a simple stack data structure with a maximum height.
public class Stack
{
    /// Gets or sets the first node in the stack.
    private StackNode? First { get; set; }
    private int MaxHeight = 0;
    private int counter = 0;

    //TODO: check
    /// Initializes a new instance of the Stack class with the specified maximum height.

    /// <param name="maxHeight">The maximum number of elements the stack can hold.</param>
    public Stack(int maxHeight)
    {
        Stack myStack = new Stack(maxHeight); //new instance of Stack
        MaxHeight = maxHeight;  //remember outside of constructor
    }

    //TODO: check
    /// Attempts to add a new item to the top of the stack.

    /// <param name="content">The content to add to the stack.</param>
    /// <returns>True if the item was successfully added; otherwise, false.</returns>
    public bool TryPush(string content)
    {
        if (!IsFull)
        {
            StackNode stackNode = new StackNode(content);   //creates a new instance of StackNode
            stackNode.Next = First; //new reference to the old first node
            stackNode = First!;  //the new first node gets first
            counter++;
            return true;
        }
        return false;
    }

    //TODO: check
    /// Attempts to remove the item at the top of the stack.

    /// <param name="content">The content of the removed item, if successful.</param>
    /// <returns>True if the item was successfully removed; otherwise, false.</returns>
    public bool TryPop(out string content)
    {
        content = "";
        if (!IsEmpty)
        {
            content = First?.Content!;
            First = First?.Next;
            return true;
        }
        return false;
    }

    //TODO: check
    /// Peeks at a specific depth in the stack without removing the item.

    /// <param name="depth">The depth to peek at, where 0 is the top of the stack.</param>
    /// <returns>The content at the specified depth, or null if the depth exceeds the stack size.</returns>
    public string? Peek(int depth)
    {
        StackNode? peek = First;
        for (int i = 0; i < depth; i++)
        {
            peek = peek?.Next;
        }
        return peek?.Content;
    }

    //TODO: finished?
    /// Gets a value indicating whether the stack is empty.
    public bool IsEmpty => First == null;

    //TODO: finished?
    /// Gets a value indicating whether the stack is full.
    public bool IsFull => counter == MaxHeight;

    //TODO: check
    /// Checks if all elements in the stack are the same.
    
    /// <returns>True if all elements are the same, or the stack is empty; otherwise, false.</returns>
    public bool IsHomogeneous()
    {
        StackNode? check = First;
        while (check != check?.Next)
        {
            while(check != null && check?.Next != null)
            {
                check = check.Next;
            }
            return true;
        }
        return false;
    }
}
