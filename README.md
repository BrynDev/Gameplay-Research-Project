# Making enemy AI shooting accuracy fair and believable
### Intro

When designing enemy AI for a first person shooter game, it's simple to make them perfectly accurate killing machines. This wouldn't feel fair to the player though, so the enemies need to miss some shots in order to offer the player a fair challenge. The goal of this project was to understand how to create a shooting AI that gives the player this fair challenge, while also making it not overtly clear that it is missing shots on purpose.
### Theory
#### Determining when to hit
There exists a fairly simple method to attain this kind of AI behavior. But while it is a simple implementation, there can be immense depth in tweaking and customization.
While the enemies are spraying bullets at the player, we keep track of an internal timer that determines when an enemy can fire an accurate shot that will actually hit its mark.
This timer is referred to as the hit delay. The calculation used to determine this is the following:

![alt text](https://i.gyazo.com/2672cd8fe7d5eb637ea7f034ae97a3c1.png)

where base delay is a chosen value and rule is the calculated weight of game state variables implemented by the designer.
Examples of possible rules include:
- Distance between player and shooter
- Velocity difference (is player running towards or away from the shooter)
- Player's orientation (crouched, prone, standing)
- Possible obstacles between player and shooter (cover)
- Player evasion rate (passive dodge chance)
More specific rules can be added depending on the type of game. A game could have different enemy types, say grunts and specialists, where specialists are a higher ranked unit and are thus more accurate in a firefight. The values of these rules can also be tweaked in order to increase or decrease the influence of each rule.

If the player has to deal with multiple enemies, which is often the case, the implementation gets more complex. In order to not let the player get riddled with bullets, often there will only be a single enemy that can land hits at a time. This can be attained using a token system where the enemy that currently has the token is capable of hitting the player. Deciding which enemy gets ownership of this token can be determined by a scoring system, where several other factors are added together to determine the current deadliest enemy. Some examples of variables to score:
- Position relative to the player (flanking)
- The enemy is currently being attacked by the player
- The enemy has not obtained the token in a long time
Some of the delay rules could also be used to calculate this score.

![alt text](https://i.gyazo.com/2459f69cf92a7d9586b85d75580518b5.png)

*In this example,a flanking enemy currently owns the token, and is thus the only one that is able to land a hit on the player*

How often the token changes hands or the hit delay is recalculated is something that can also be tweaked for varying changes in behavior.
Besides this, the weights and values for each of these rules can also be easily adjusted according to the game's difficulty setting. Having more or less accurate or agressive AI is a much more interesting way to raise difficulty than simple changes to damage numbers.
### Implementation
I attempted to demonstrate this hit delay system using a playable Unity project that features one enemy. The rules that were taken into account for calculating the hit delay were the player's velocity and distance in relation to the enemy.
![alt text](https://i.gyazo.com/6210f63e13c1af1dcea302bd2b7671ba.png)
In order to make missed shots feel believable, any bullets that were fired before the hit delay had a small offset applied to their traveling trajectory. This was done in order to create near-misses. The goal is to make the player believe that the AI is making an honest mistake by missing their shots. The result is that the majority of bullets will be aimed at a semicircle around the player's head.

![alt text](https://i.gyazo.com/a206c7a459db9e00842afd09535a64bd.png)

### Conclusions
The implementation successfully showed a difference in hit rate depending on the rules used. The shooter fired 50 bullets per salvo, with 8 bullets per second. When standing still at a long distance the player got hit by 4 bullets. While running into mid range this turned to 6, and went up to 8 as the player continued approaching. Though this is a simple project, the results were clearly visible. Although it can be hard to reach a good balance for the delay timer due to needing to carefully adjust several values, I believe that this system can be used to achieve great results when more factors are taken into consideration.
### Sources
https://core.ac.uk/download/pdf/33504361.pdf
https://core.ac.uk/download/pdf/14900028.pdf
http://www.gameaipro.com/GameAIPro3/GameAIPro3_Chapter33_Using_Your_Combat_AI_Accuracy_to_Balance_Difficulty.pdf
