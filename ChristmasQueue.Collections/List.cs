namespace ChristmasQueue.Collections;

/// <summary>
/// Represents a node in a list, holding a stack and a reference to the next node.
/// </summary>
/// <remarks>
/// Note that the class is "internal". That means that it is only visible inside the
/// project. Other projects cannot access it.
/// </remarks>

internal class ListNode
{
    /// Gets the stack contained in this node.
    public Stack Stack { get; }

    /// Gets or sets the next node in the list.
    public ListNode? Next { get; set; }

    /// Initializes a new instance of the ListNode class with a stack of specified maximum height.

    /// <param name="maxStackHeight">The maximum height of the stack contained in this node.</param>

    public ListNode(int maxStackHeight)
    {
        Stack = new(maxStackHeight);
    }
}

/// Represents a list of stacks.
public class ListOfStacks
{
    /// Gets or sets the first node in the list.
    private ListNode? First { get; set; } = null;


    /// Initializes a new instance of the ListOfStacks class with the specified number of stacks, each having a specified maximum height.

    /// <param name="numberOfStacks">The number of stacks to create in the list.</param>
    /// <param name="maxStackHeight">The maximum height of each stack in the list.</param>
    public ListOfStacks(int numberOfStacks, int maxStackHeight)
    {
        ListNode newListNode = new ListNode(maxStackHeight);
        for(int i = 0; i < numberOfStacks - 1; i++)
        {
            newListNode = new ListNode(maxStackHeight);
            newListNode.Next = First;
            First!.Next = First;
        }
    }

    /// Gets the stack at a specific index in the list.

    /// <param name="stackIndex">The index of the stack to retrieve.</param>
    /// <returns>The stack at the specified index, or null if the index is out of range.</returns>
    public Stack? GetAt(int stackIndex)
    {
        ListNode? get = null;
        for(int i = 0; i < stackIndex; i++)
        {
            get = First?.Next;
        }
        
        return get?.Stack;
    }

    /// Determines whether all stacks in the list are homogeneous (i.e., all elements in each stack are the same).

    /// <returns>True if all stacks are homogeneous; otherwise, false.</returns>
    public bool AreAllStacksHomogeneous()
    {
        return true;
    }
}
