![Static Badge](https://img.shields.io/badge/Unity-2022.3.0-brightgreen?logo=Unity&logoColor=%23e4eeff) ![Static Badge](https://img.shields.io/badge/Project_version-1.0.2-%23191922?logo=gamejolt&logoColor=%23e4eeff)

# Clicker Game Template
Clicker game template being developed for educational purposes

# Project name: 
Clicker game with progression

# Project Description:
The project is a clicker game in which the player fights enemies, earning money and experience. The game is oriented for mobile devices in vertical position, but it is suitable for other platforms and devices. There are no graphics as it is a template for the game and stubs are used.

An example of my finished game: [Link][Game]

# Main components and mechanics:

* **Player**: The player starts with one hero and can click on enemies to deal damage. By killing enemies, the player gains money and experience.

* **Money**: The player can use money to buy new heroes.

* **Experience**: Experience is gained with each enemy killed. When the player gains enough experience, he increases his level.

* **Progression**: The difficulty of the game increases exponentially with the player's level. Enemies become stronger and require more effort to destroy.

* **Interface**: The main screen displays the current currency, the player's level, and a button to attack an enemy. Below that is a scrolling menu with available heroes for purchase.

   ![Interface image](https://i.ibb.co/ZzHWbwP/photo-2023-11-05-23-42-56.webp)

# Technical Details:

* **Platform**: The game is developed under the WebGL platform, which allows it to run in web browsers.

* **Programming Language and Engine**: The game is being developed using C# programming language and Unity Engine.

* **Game architecture**: The architecture of developer [vavilichev: Lukomor][arch developer] is taken as a basis.

* **Patterns**: The Object Pool pattern is used to control the number of created particles displaying damage. To simplify the work with the main resources (wallet, levels and hero) in the game is used pattern Facade

* **Editor**: To edit enemies (their number and characteristics) is used custom inspector window.

   ![Editor image](https://i.ibb.co/6vnFgsy/Screenshot-2023-12-12-202930.png)

* **Development Time**: The game was developed within a week and a half.

* **Additional functional features**:

    * Adding different heroes with unique characteristics that the player can purchase.
    * Ability to save and load the game.

[arch developer]: https://github.com/vavilichev/Lukomor
[Game]: https://yandex.ru/games/#app=270313%3Futm_source%3Ddistrib&clid=2968906&vid=ga
