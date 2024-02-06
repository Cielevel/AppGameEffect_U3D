# Actor 与 Behavior 关系图

被存储到 SO 的行为可以针对不同种类的角色进行配置。

- 举例：
  - 主角-行为：
    1. 共有行为->移动、跳跃、攻击、交互
    2. 独有行为->主角行为（单独配置）
  - 敌人：
    - 吸血鬼-行为：
      - 共有行为->移动、跳跃、攻击、追逐（追踪式移动）
      - 独有行为->吸血鬼行为（吸血、通过吸血回血、等）

---

```mermaid
graph RL

GameActor((角色actor))
Behaviors(behavior)
SharedBehavior(通用共有的行为-集合)
OwnBehavior(角色独有行为)
BaseBehavior(基-行为)
FSM(状态机FSM)
AnimatorManager(动画管理器AnimatorManager)

Move-Behavior(移动-行为)
Interact-Behavior(交互-行为)

A-Behavior(A行为)
B-Behavior(B行为)
C-Behavior(C行为)

style GameActor fill: orange
style Behaviors fill: green

subgraph 行为持有关系
	GameActor---|持有行为|Behaviors
  Behaviors-->SharedBehavior
	Behaviors-->OwnBehavior
end

SharedBehavior-->通用共有行为-SO
OwnBehavior-->独有行为-SO

subgraph 行为
subgraph 独有行为-SO
A-Behavior
B-Behavior
C-Behavior
end

subgraph 通用共有行为-SO
Move-Behavior
Interact-Behavior
end
end

subgraph 行为关系
通用共有行为-SO & 独有行为-SO ==>|继承|BaseBehavior
BaseBehavior<-->|使用行为|GameActor
end

BaseBehavior<==>|持有&调用|FSM==>|调用|AnimatorManager
```
