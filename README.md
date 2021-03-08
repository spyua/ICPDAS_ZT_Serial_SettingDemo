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
