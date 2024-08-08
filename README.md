Report
Red-Black Trees are a type of self-balancing binary search tree that ensures the tree remains approximately balanced during insertions and deletions. This balance is crucial as it guarantees that the time complexity for common operations such as search, insertion, and deletion remains O(log n), where n is the number of nodes in the tree.

A Red-Black Tree maintains the following properties to ensure balance:

Property 1: Every node is either red or black.
Property 2: The root is always black.
Property 3: Every leaf (NIL) is black.
Property 4: If a node is red, then both its children are black (no two red nodes can be adjacent).
Property 5: For each node, all paths from the node to its descendant leaves contain the same number of black nodes.

The Insert method is responsible for inserting a new node into the tree. It first locates the appropriate position for the new node and then invokes the FixInsert method to ensure that the Red-Black Tree properties are maintained.

The FixInsert method ensures that the Red-Black Tree properties are not violated after a new node is added. This is achieved through a series of rotations and recoloring operations.

Rotations are crucial for maintaining the balance of the tree during insertions and deletions. The Red-Black Tree uses two types of rotations: Left and Right.

The Delete method removes a node from the tree. Similar to insertion, it ensures that the Red-Black Tree properties are maintained after the removal through the FixDelete method.

The Red-Black Tree ensures that the tree remains balanced, keeping the height of the tree as low as possible. This balance guarantees that the time complexity for searching, inserting, and deleting operations remains logarithmic, O(log n), making the Red-Black Tree an efficient data structure for maintaining sorted data.

In conclusion, the Red-Black Tree is a powerful self-balancing binary search tree that ensures efficient data management. The implementation provided includes crucial operations such as insertion, deletion, and balancing through rotations and recoloring, ensuring that the tree remains balanced after every operation.
VISUAL AID
[RB pamphlet.docx](https://github.com/user-attachments/files/16553888/RB.pamphlet.docx)

Reference
https://youtu.be/ZxCvM-9BaXE?si=lANQdC3dCSZhxR9h
