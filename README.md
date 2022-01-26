# CS496 Immersion Camp (Winter 2021)

# Project #4: Open World Game

## Team

김동휘([https://github.com/qsenn](https://github.com/qsenn))

송성민([https://github.com/reverg](https://github.com/reverg))

이희우([https://github.com/HeeWooLee](https://github.com/HeeWooLee))

## Introduction

Unity 기반의 Multi-Play 가능한 Open World 게임이다. 서버는 node js에 mongoDB를 연결하여 만들었고 모델링에는 Blender를 사용하였다.

## Before Start

### Set Username

 게임 시작 전에 다른 유저들에게 보여질 자신의 이름을 설정할 수 있다. Player 아바타 위에 설정한 이름이 나타난다.

### Basic Motion Info

 `Up, Down, Left, Right` 또는 `W, A, S, D` 를 눌러 걸어다닐 수 있다. `Space` 를 누르면 점프한다.  카메라 시점은 마우스 움직임에 따라 자연스럽게 따라온다.

## Enjoy Game

### Hike Mountain

 맵에 있는 큰 산을 등산할 수 있다.
 <div align=center> <img src = "https://user-images.githubusercontent.com/48681924/151151841-9a3730d4-2243-40df-a593-e85d94e60e31.png" width="80%" height="80%"></div>

### Swim in Pond

맵에 있는 연못의 물과 접촉하면 수영 모션으로 바뀐다. 이동할 때는 평영 모션을 취하다 멈추면 수중에 떠 있는 모션으로 전환된다. 땅으로 나오게 되면 다시 걷는 모션으로 전환된다.
<div align=center> <img src = "https://user-images.githubusercontent.com/48681924/151151820-b606f43a-f236-4093-b2c8-d5915506b10b.png" width="80%" height="80%"></div>

### Dance in Club

집 모양의 클럽으로 들어가면 플레이어 모션이 춤추는 모션으로 전환된다. 클럽 내의 NPC들과 같이 춤을 출 수 있다.

---

[https://github.com/MadCampWeek4-2022](https://github.com/MadCampWeek4-2022)
