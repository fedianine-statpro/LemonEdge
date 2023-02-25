
# LemonEdge Coding Exercise
This solution was written in 3.5 hours by Victor Fedianine

## Answers for each chess piece

- King - 2929 phone numbers
- Queen - 33568 phone numbers
- Knight - 162 phone numbers
- Rook - 1564 phone numbers
- Bishop - 225 phone numbers
- Pawn - 57 phone numbers

Note: For pawn, the assumption is that it can only move up and down one space.

## Notes from the developer

Tests written should cover a lot of the basic use cases, but code is not fully covered as I believe the most 
important is simply to show that I understand how testing is done. Also, I know how to Mock classes
but in this instance, I thought it would be overkill.

The code that I generated allows :
- new keyboard layout (see SquareBoard and DoughnutBoard). As you may find, I allow nulls as part of the board, 
enforcing chess pieces not to use parts of the board with a null.
- different rules, where the user can specify any telephone number length and even specify a custom regex
- new chess pieces

## Questions? 

### How do you know what you have developed is correct? 
I know that my code is correct because I have done thorough manual and automated testing. 

Also, I followed good coding practices, such as using meaningful variable and function names, commenting code, and breaking down complex tasks into smaller, more manageable pieces. 

### How can you make it more efficient? 
- It's possible to do a lot of things in parallel using async libraries. 
- Also, more caching can be done. For example cache the results of IsValidPosition - 
this method is called multiple times for each position, so caching its results could save some computation time.
- Avoid creating new Location objects - instead of creating new Location objects for each move, reuse existing objects.

## How to run the code

Just execute the LemonEdge project console application