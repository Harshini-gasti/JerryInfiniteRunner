
                                                       **Jerry Infinite Runner**
A Unity endless runner game built to demonstrate object pooling, optimized spawning, and data persistence using JSON.

                 Features
Object Pooling for collectibles like Cheese and Apple

Efficient spawning system

Player movement handled using Update()

Physics handled using FixedUpdate()

Save and load game data using JSON

Performance optimized for smooth gameplay

              Object Pooling
Game objects are reused instead of repeatedly creating and destroying them, improving performance.

    Example:

GameObject obj = pool.GetPooledObject();
if (obj != null)
{
    obj.SetActive(true);
}
Update vs FixedUpdate
Update() → Handles player input and frame-based logic

FixedUpdate() → Handles physics and Rigidbody movement

         Data Saving (JSON)
Game data such as score is stored and loaded using JSON serialization.

    Example:

string json = JsonUtility.ToJson(gameData);
File.WriteAllText(path, json);
Tech Stack
Unity
C#
JSON Serialization
