public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1
        // Base Case: prevent duplicates if value exists already
        if (value == Data)
        {
            return;
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        // Base Case: return true if value exists in node
        if (value == Data)
        {
            return true;
        }
        // Check left when value is smaller
        if (value < Data)
        {
            if (Left != null)
            {
                return Left.Contains(value);
            }
        }
        // Check right when value is larger
        else
        {
            if (Right != null)
            {
                return Right.Contains(value);
            }
        }
        // Return false when value not found
        return false;
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        // Setting heights to zero covers when left or right do not exist
        int leftHeight = 0;
        int rightHeight = 0;
        // Get the height of left when it exists
        if (Left != null)
        {
            leftHeight = Left.GetHeight();
        }
        // Get the height of right when it exists
        if (Right != null)
        {
            rightHeight = Right.GetHeight();
        }
        // Return the highest height plus 1 (accounting for the root node)
        if (leftHeight > rightHeight)
        {
            return leftHeight + 1;
        }
        else
        {
            return rightHeight + 1;
        }
    }
}