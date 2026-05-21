using System;
using System.Collections.Generic;



/// <summary>
/// This queue is circular.  When people are added via AddPerson, then they are added to the 
/// back of the queue (per FIFO rules).  When GetNextPerson is called, the next person
/// in the queue is saved to be returned and then they are placed back into the back of the queue.  Thus,
/// each person stays in the queue and is given turns.  When a person is added to the queue, 
/// a turns parameter is provided to identify how many turns they will be given.  If the turns is 0 or
/// less than they will stay in the queue forever.  If a person is out of turns then they will 
/// not be added back into the queue.
/// </summary>
public class TakingTurnsQueue 
{
    private readonly Queue<Person> _queue = new Queue<Person>();

    public int Length => _queue.Count;
    /// <summary>
    /// Add new people to the queue with a name and number of turns
    /// </summary>
    /// <param name="name">Name of the person</param>
    /// <param name="turns">Number of turns remaining</param>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _queue.Enqueue(person);
    }

    /// <summary>
    /// Get the next person in the queue and return them. The person should
    /// go to the back of the queue again unless the turns variable shows that they 
    /// have no more turns left.  Note that a turns value of 0 or less means the 
    /// person has an infinite number of turns.  An error exception is thrown 
    /// if the queue is empty.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _queue.Dequeue();
        //infinite turns: 0 or negative always re enqueue without changing turns
        if (person.Turns <= 0)
        {
            _queue.Enqueue(person);
        }
        //use up a turn and re enqueue if they have turns left
        else
        {
            person.Turns--;
            if (person.Turns > 0)
            {
                _queue.Enqueue(person);
            }
            // else they are out of turns and should not be re-enqueued
        }
        return person;
    }
    //Person class is here for testing purposes.  It is not part of the requirements for the TakingTurnsQueue class and should not be used in the implementation of the TakingTurnsQueue class.  It is only used in the tests to verify that the turns parameter is being updated correctly and that people with infinite turns are not having their turns parameter modified to a very big number.
    public class Person
    {
        public string Name { get; }
        public int Turns { get; set; }

        public Person(string name, int turns)
        {
            Name = name;
            Turns = turns;
        }

        public override string ToString()
        {
            return $"{Name} ({Turns} turns)";
        }
    }
}