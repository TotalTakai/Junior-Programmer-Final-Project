# Junior Programmer: Final Mission Checkpoint Project
Work in progress

This Project is a summary of my junnior programming path in Learn.Unity.

This project will include:
- Demonstration of abstraction
- Demonstration of inheritance
- Demonstration of polymorphism
- Demonstration of encapsulation

I will also try to include self learnt design patterns such as:
- Singleton to maintain data with the usage of Jasons
- Object Pooling
- Factory Design

As it will take a longer time then most of my project I will try to update this readme with random thoughts and relevant links.
Started working on this project at 12/07/2023


12/07 Update:
Adding My Project Design Document - https://docs.google.com/document/d/1CBsrgPQF8RxY4wJE1XaK2s7aw0Ue4SJ-h46mQAG3uFM/edit?usp=sharing
- Added Basic player movement
- Added Camera follow
- Added logic for passthrough platform (in Unity and PlayerController's code)

13/07 Update:
Spent most of the day reading about abstracts and interfaces to make sure I make the game scaleable, so only a short update:
- Added a weapon that pivots around the character pointing at the mouse position
- fixed a bug that denied the player from jumping if he tried to down jump from the ground

14/07 Update:
Another small update, having been racking my brain about how to build the weapon system. Decided to have a weapon abstract with all the logic, with the specific
weapons having the information for scalabilty matters. Right now decided on onAttack event which might change to become an abstract method. Right now learning
about Raycasting for shooting the guns.
- Added weapon abstract script for all weapons
- Added Pistol script (derived from weapon abstract)

16/07 Update:
-Implemented Enemy Weapon Auto-aim
-Started working on BulletAbstract and PistolBullet scripts which holds the bullet behavoir (takes a lot longer then I thought). // I feel as if they are correct but can't test them without a proper Weapon Abstract
- Editted the weapon abstract and maybe broken it a bit, will need to work on it again, might have to devide enemy from player, or find another way to fix the code





No playable version atm