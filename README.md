# FlappyEvader
## Evade as many missiles as you can!

### Description:
Survive as long as you can, dodge all heatseeking missiles, use the terrain to your advantage and time your flares correctly.
The longer you survive the smarter the missiles gets.

### Notes:
This repository uses LFS to store .obj files, so please install git LFS and clone this repository correctly by using the following command:
git lfs clone <repo>

### TODO
- [ ] Improve flight model with/without physics
- [ ] Death on ground collision
- [ ] Create missile /w physics or simple transform
	- [ ] Implement seek and steer behaviour
	- [ ] Implement proportional navigation behaviour
	- [ ] Adjust accuracy on both (as user progresses, missile become more accurate)
	- [ ] Implement augmented proportional navigation
	- [ ] Implement collision avoidance
	- [ ] Death on collision
- [ ] Create flares as countermeasure
- [ ] Improve 3D model assets
	- [ ] Create a better looking plane
	- [ ] Create better looking terrain
	- [ ] Create explosion / crash animation (for both plane + missile)
	- [ ] Thrust heat/smoke (plane + missile)
	- [ ] 
- [ ] Create SFX
- [ ] GUI
	- [ ] Hiscores (maybe publish online?)