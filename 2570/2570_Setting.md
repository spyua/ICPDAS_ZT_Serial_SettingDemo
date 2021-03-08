## ZigBee機器設置-2570 (ModBus TCP)


### [Tool: ZT Configuration Utility](http://www.icpdas.com/en/download/show.php?num=2845&model=ZT-2018/S)

#### 基礎參數設置

![image](https://user-images.githubusercontent.com/20264622/110278008-63143480-8011-11eb-8bd8-ad30cf5e2e67.png)
 
 - Pan ID:同網域中的ZigBee Pan ID需相同。
 - Node ID:自行編號，勿重複。
 - RF頻道: 建議4 9 1 f 或使用Wifi Power Scanner看一下哪個區段頻
 - Power: 建議就使用標準規範。

 ---
 
#### TCP參數

![image](https://user-images.githubusercontent.com/20264622/110278305-f8afc400-8011-11eb-86d1-568f3c19601f.png)


 - IP , Port, GateWay設置
 
  ---
  
#### 進階ZigBee參數設置
 
 ![image](https://user-images.githubusercontent.com/20264622/110280716-43cbd600-8016-11eb-8158-2e913513d331.png)
 
 - 通訊速度
 
這個數值填ZT slave的數量，例如:2055*2 + 2571*2 = 4，主要是控管無線封包的輪詢速度，避免PC端問太快，但無線封包還沒消化完而造成資料都塞車在2570身上，不過，若PC端的輪詢速度1秒問1站，這樣就不會塞車在2570身上。

  ---
  
#### 工作模式

  ![image](https://user-images.githubusercontent.com/20264622/110280746-50e8c500-8016-11eb-8a3a-b77d99842f51.png)
  
  - 工作模式 : Modbus TCP選用Gateway模式。


   
