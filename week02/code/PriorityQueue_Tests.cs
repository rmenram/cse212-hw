using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add items (which contains both data and priority) to the back of the queue
    // Expected Result: [Item1 (Pri:1), Item2 (Pri:5), Item3 (Pri:10)]
    // Defect(s) Found: 
    public void TestPriorityQueue_Back()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 1);
        priorityQueue.Enqueue("Item2", 5);
        priorityQueue.Enqueue("Item3", 10);

        String expectedResult = "[Item1 (Pri:1), Item2 (Pri:5), Item3 (Pri:10)]";

        Assert.AreEqual(expectedResult, priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: remove the item with the highest priority and return its value
    // Expected Result: Remove items in the following order -> Item3, Item2, Item1
    // Defect(s) Found: 
    //  Bug 1:  The loop in the Dequeue does not go through the whole queue (_queue.Count - 1) 
    //          so it does not get to the item with the highest priority 
    //  Bug 2:  The Dequeue method does not dequeue (it does not remove any items)
    public void TestPriorityQueue_Priority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 1);
        priorityQueue.Enqueue("Item2", 5);
        priorityQueue.Enqueue("Item3", 10);

        Assert.AreEqual("Item3", priorityQueue.Dequeue());
        Assert.AreEqual("Item2", priorityQueue.Dequeue());
        Assert.AreEqual("Item1", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: remove the item with the highest priority and return its value
    // Expected Result: Remove items in the following order -> Item2, Item3, Item1
    // Defect(s) Found: 
    //  Bug 1:  The loop in the Dequeue does not go through the whole queue (_queue.Count - 1) 
    //          so it does not get to the item with the highest priority 
    //  Bug 2:  The Dequeue method does not dequeue (it does not remove any items)
    //  Bug 3:  The tie breaker goes to the second item rather than the first item
    public void TestPriorityQueue_TieBreaker()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 1);
        priorityQueue.Enqueue("Item2", 10);
        priorityQueue.Enqueue("Item3", 10);

        Assert.AreEqual("Item2", priorityQueue.Dequeue());
        Assert.AreEqual("Item3", priorityQueue.Dequeue());
        Assert.AreEqual("Item1", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to get the next item from an empty queue
    // Expected Result: Exception should be thrown with appropriate error message.
    // Defect(s) Found: None
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }

}