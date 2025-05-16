# FinalProject

Video Link: https://youtu.be/kN4a0fY_4uo

I aimed for an A+!


START GAME
-----------------------------------------------------------
Choose your character from the list of characters, which starts game set up to do the following:

  ~ Call PlayerFactory
    - adds a starting weapon to Player
    - adds default ability "Stab" to Player
    
  ~ Call RoomFactory
    - locates each Room in Rooms table and assigns them to variable
    - adds associated Items and Enemies to the Room's Items and Enemies lists



***MAIN MENU***
-----------------------------------------------------------
1. Enter the RPD (gameplay start)
2. Admin Menu



***ADMIN MENU***
-----------------------------------------------------------
1. Character Management Menu
   
   ~ Display all characters **REQUIRED**
     - along with their attributes
       
   ~ Add new character - **REQUIRED**

   ~ Remove existing character
     - choosing character by PlayerId
  
   ~ Edit existing character - **REQUIRED**
     - choosing character by PlayerId
       
   ~ Search character by name - **REQUIRED**
     - full name, case in-sensitive
   
   ~ Display character abilities - **C-LEVEL**
     - choosing character by PlayerId
       
   ~ Add ability to character - **C-LEVEL**
      - choosing character by PlayerId
      - choosing ability by PlayerAbilityId
  
   ~ Remove ability from character
     - choosing character by PlayerId


2. Inventory Management

   ~ Display all items
     - along with description, attribute, and
       **location (even what character is holding it and where the character is located)** - **A-LEVEL**

   ~ Search for item by name
     - full name, case in-sensitive

   ~ List item by type
     - Weapon
     - FirstAid
     - KeyItem
  
  ~ -------Sort Items Submenu-------
  1. Sort by Name
    -*BROKEN* lists items alphabetically
      
  2. Sort by Damage Value
    - sorts from lowest to highest damage value

  3. Sort by Healing Value
    - sorts from lowest to highest healing value

  4. Sort by Used or Not
    - sorts which items are used or not


3. Room Management

  ~ Display all rooms - **B-LEVEL**
    - along with description, items within, and **characters within** - **A-LEVEL**

  ~ Add new room **B-LEVEL**

  ~ List characters in room by attribute - **C-LEVEL**
    - *USELESS* because no room has more than one character at the time of this menu



***GAMEPLAY***
-----------------------------------------------------------
~ Execute an ability during attack - **C-LEVEL**

~ Navigate rooms - **B-LEVEL**

~ Combat system is a little more advanced with player choosing abilities to attack with
  and enemies having a random ability to attack with in return **A+ STRETCH LEVEL**

~ Several enemy types with their own unique abilities **A+ STRETCH LEVEL**

~ Player goal (not fully fleshed out, but still present) where player cannot win until
  certain KeyItems are found and used to unlock a room **A+ STRETCH LEVEL**

~ Looting system **A+ STRETCH LEVEL**

~ Weapon swapping (function is there, method was not implemented) **A+ STRETCH LEVEL**



***EXTRAS***
-----------------------------------------------------------

~ Created my own database directly from scratch and built program from the ground up
  with *some* assets used from previous templates:             **A+ STRETCH LEVEL ?**
    - OutputManager, MenuManager, Startup, GameContextFactory ITargetable

~ Utitlized EF Migrations a massive amount instead of instantiating items on game startup,
  learned a lot and only broke down once!! XD  **A+ STRETCH LEVEL ?**


This was a fun challenge and by far the biggest project I've made to date! Loved utilizing EF Core
but did find it frustrating when it came to configuring entity relationships. There's a lot I need
to learn, I'm sure. Thank you for a great semester, Mark!!










