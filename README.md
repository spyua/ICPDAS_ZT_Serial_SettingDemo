# ICPDAS_ZT_Serial_SettingDemo
ICP DAS Zigbee 2570, 2571,TCP Setting使用紀錄  2055設置

### 設備

 - ZT-2570 : Data Gathering，負責主動訪問或下命令給ZT-2055 IO輸出輸入狀態，或是與2571做資料傳輸(工作模式:透明模式)。
 - ZT-2571 : 做Router或是可與2570做資料傳輸(工作模式:透明模式)。
 - ZT-2055 : End Device，控制終端設備，有Io輸出。
 
 註:透明模式，ICPDAS特別設計，若2570與2571想做資料雙向溝通就得選此模式。不然一般狀況下ICPDAS設置為訪問制，2570須主動訪問其他型號ZigBee。
 
### 設置
 一般ZigBee網域在監控端會有一個Gathering，接著會設置不同End Device去控制其他終端設備。如果距離太遠可在中間設置Router。
 
#### Case Sample

![image](https://user-images.githubusercontent.com/20264622/110338567-1c9af600-8062-11eb-9078-2a60b10c812f.png)

 此例為一個簡易ZigBee網絡，具有一個終端收集器與一個Router，終端設備控制自動門的開與關。
 
#### 設定

 - [Step1 : 2570設置](2570/2570_Setting.md)
 - [Step2 : 2571設置](2571/2571_Setting.md)
 - [Step3 : 2055設置](2055/2055_Setting.md)

#### Code
 - Set 2570 IP,Port on appsetting.json
 - Run起程式
 
 你可以根據Case Sample，若你要訪問2055 IO狀態可以透過程式試發資料如下
 ```
   byte[] bytes = { 0x00, 0x01, 0x00, 0x00, 0x00, 0x06, nodeID, 0x02, 0x00, 0x00, 0x00, 0x0A };
 ```
 發出去後程式會自動解析2055回吐的IO狀態，其餘動作可根據ModBusTCP命令去設計指令互動。

#### 補充(Modbus簡易描述)

##### Modbus有分3種
![image](https://user-images.githubusercontent.com/20264622/110444600-2ff8a080-80f8-11eb-9ef3-7c11e3f88593.png)

 - 1.Modbus TCP (紅框+藍框), 
 - 2.Modbus ASCII (藍框的內容要再轉成ASCII，長度較長，所以較少用), 
 - 3.Modbus RTU (藍框)
 
 紅框: TCP的Header，籃框內容如下:

 - 站號: 0x08
 - 命令碼: 0x02
 - 起始位址: 0x0000
 - 資料長度: 0x0008
 - CRC16檢查碼: 0x7955
 
 ##### ZigBee 訊號微弱修正建議

![image](https://user-images.githubusercontent.com/20264622/110444857-76e69600-80f8-11eb-8cae-56c3c26b061f.png)

訊號不好的時候，有3個方式加強訊號 (ZT拓樸軟體量測)

 - (1) ZT模組都有內建訊號放大器，可用軟體設定將RF Power調大到0F，但因為無線認證的時候是預設08，所以調整後我們就不保證認證

 - (2) 更換天線。出廠標配是2.4GHz 5dBi的天線，可外購更大dBi的天線

 - (3) 加裝repeater進行資料轉傳。 目前門上方的2055已有轉傳的能力，若還是無法傳出去，就要找窗戶邊加裝repeater試著將無線訊號傳出去


註一 : 因為ZigBee是小資料量、慢速讀取的應用，所以若可以，建議1秒輪詢1站。

註二 : RF Channel ZigBee推薦 4 9 E 

註三 : 傳輸大小最大79 bytes




  
 
 
