import os
import mcrcon
import ping3
import sys
import platform
import datetime

# ANSI 转义码定义
class ANSIColors:
    RED = '\033[91m'
    GREEN = '\033[92m'
    YELLOW = '\033[93m'
    RESET = '\033[0m'

# 将 Minecraft 格式化字符串中的 § 替换为对应的 ANSI 转义码
def translate_colors(text):
    text = text.replace("§0", "\033[30m")  # 黑色
    text = text.replace("§1", "\033[34m")  # 深蓝色
    text = text.replace("§2", "\033[32m")  # 深绿色
    text = text.replace("§3", "\033[36m")  # 深青色
    text = text.replace("§4", "\033[31m")  # 深红色
    text = text.replace("§5", "\033[35m")  # 紫色
    text = text.replace("§6", "\033[33m")  # 金色
    text = text.replace("§7", "\033[37m")  # 灰色
    text = text.replace("§8", "\033[90m")  # 深灰色
    text = text.replace("§9", "\033[94m")  # 蓝色
    text = text.replace("§a", "\033[92m")  # 绿色
    text = text.replace("§b", "\033[96m")  # 青色
    text = text.replace("§c", "\033[91m")  # 红色
    text = text.replace("§d", "\033[95m")  # 粉色
    text = text.replace("§e", "\033[93m")  # 黄色
    text = text.replace("§f", "\033[97m")  # 白色
    text = text.replace("§l", "\033[1m")   # 粗体
    text = text.replace("§o", "\033[3m")   # 斜体
    text = text.replace("§n", "\033[4m")   # 下划线
    text = text.replace("§m", "\033[9m")   # 删除线
    text = text.replace("§r", ANSIColors.RESET)  # 重置所有格式

    return text

# 检查 showlogo.ini 文件是否存在以及其值是否为 false
show_logo = True
if os.path.exists("showlogo.ini"):
    with open("showlogo.ini", "r") as file:
        show_logo_setting = file.read().strip().lower()
        if show_logo_setting == "false":
            show_logo = False
            
# 检查 eula.ini 文件中的 EULA 条款是否存在，以及 eula 值是否为 true（同意条款）
if os.path.exists("eula.ini"):
    with open("eula.ini", "r", encoding="utf-8") as file:
        eula_setting = file.readline().strip().lower()
        if eula_setting != "true":
            print(ANSIColors.RED + "您尚未同意 Minecraft 的 EULA！" + ANSIColors.RESET)
            print(ANSIColors.YELLOW + '如果您不同意条款，我们将无法为您提供软件服务。' + ANSIColors.RESET)
            print(ANSIColors.YELLOW + '请在重新启动程序之前将 eula.ini 中的 "false" 改为 "true" 以签署协议。' + ANSIColors.RESET)
            print(ANSIColors.YELLOW + '有关 Minecraft EULA 的更多信息，请参阅 https://www.minecraft.net/zh-hans/eula' + ANSIColors.RESET)
            exit()
else:
    with open("eula.ini", "w", encoding="utf-8") as file:
        file.write("false\n")
        file.write("# 有关 Minecraft EULA 的更多信息，请参阅 https://www.minecraft.net/zh-hans/eula\n")
        file.write("# 如果您购买、下载或使用 Minecraft 的任何服务，或者如果您接受本 EULA，则意味着您同意本 Minecraft EULA 和微软服务协议，因此请仔细阅读它们。\n")
        file.write("# 如果您是未成年人，在理解这些条款和条件方面有困难，请要求您的父母或法定监护人解释，尤其是在您的父母或法定监护人负责创建您的微软帐户并代表您接受所有条款时。\n")
        file.write("# 如果拒绝条款，那么原则上你不应该使用该软件。\n")
        file.write("\n")
        file.write("# 该 Eula 的生成时间为 " + datetime.datetime.now().strftime("%Y-%m-%d %H:%M:%S"))
        
    print(ANSIColors.RED + "您尚未同意 Minecraft 的 EULA！" + ANSIColors.RESET)
    print(ANSIColors.YELLOW + '如果您不同意条款，我们将无法为您提供软件服务。' + ANSIColors.RESET)
    print(ANSIColors.YELLOW + '请在重新启动程序之前将 eula.ini 中的 "false" 改为 "true" 以签署协议。' + ANSIColors.RESET)
    print(ANSIColors.YELLOW + '有关 Minecraft EULA 的更多信息，请参阅 https://www.minecraft.net/zh-hans/eula' + ANSIColors.RESET)
    exit()
    

if show_logo:
    print(ANSIColors.RED + '   ')
    print("■■■   ■■■■     ■                            ■■■■■■■        ■■■ ■     ■■■■    ■■■   ■■■■")
    print("■■■■  ■■■■    ■■■                           ■■■■■■■■     ■■■■■■■    ■■■■■■   ■■■■  ■■■■")
    print(" ■■■  ■■■     ■■                             ■■   ■■■   ■■■   ■■■  ■■    ■■   ■■■   ■■ ")
    print(" ■■■  ■■■                                    ■■    ■■   ■■     ■■  ■     ■■   ■■■■  ■■ ")
    print(" ■■■  ■■■    ■■■■     ■■■ ■■■        ■■■     ■■    ■■  ■■      ■■ ■■      ■■  ■■■■  ■■ ")
    print(" ■■■ ■■■■    ■■■■     ■■■■■■■■     ■■■■■■■   ■■■■■■■   ■■         ■■      ■■  ■■ ■  ■■ ")
    print(" ■■■ ■■■■      ■■      ■■■   ■■    ■     ■   ■■■■■■    ■■         ■■      ■■  ■■ ■■ ■■ ")
    print(" ■■■■■■■■      ■■      ■■    ■■   ■■■■■■■■■  ■■ ■■■    ■■         ■■      ■■  ■■  ■ ■■ ")
    print(" ■■■■■ ■■      ■■      ■■    ■■   ■■■■■■■■■  ■■  ■■    ■■         ■■      ■■  ■■  ■■■■ ")
    print(" ■■■■■ ■■      ■■      ■■    ■■   ■■         ■■  ■■    ■■      ■■ ■■      ■■  ■■   ■■■ ")
    print(' ■■ ■■ ■■      ■■      ■■    ■■   ■■      ■  ■■   ■■   ■■      ■■  ■     ■■   ■■   ■■■ ')
    print(' ■■ ■■ ■■      ■■      ■■    ■■   ■■■    ■■  ■■   ■■    ■■    ■■   ■■    ■■   ■■   ■■■ ')
    print('■■■■■■■■■■   ■■■■■■   ■■■■  ■■■■   ■■■■■■■  ■■■■   ■■■   ■■■■■■     ■■■■■■   ■■■■   ■■ ')
    print('■■■■■ ■■■■   ■■■■■■   ■■■■  ■■■■    ■■■■■   ■■■■   ■■■    ■■■■       ■■■■    ■■■■   ■■ ')
    print('   ' + ANSIColors.RESET)
    print(ANSIColors.YELLOW + '如果你想要在之后启动中不显示字符画，你可在程序或代码所在文件夹创建 showlogo.ini 并向内部写入 false 来关闭它。' + ANSIColors.RESET)

print(ANSIColors.GREEN + '欢迎使用 MineRCON！主程序版本 P1.20 - Python 构建版本', sys.version, '- 系统核心版本', platform.uname().release + ANSIColors.RESET)

# 获取用户输入的 IP 或主机名
while True:
    host = input("输入你的 IP 或主机名: ")
    if host:
        break
    else:
        print(ANSIColors.RED + "无效 IP 或主机名" + ANSIColors.RESET)

# 获取用户输入的端口
port = input("指定端口（缺省代表使用默认 25575）: ")
if not port:
    port = 25575
else:
    port = int(port)

# 预检测环节，根据网络状态评级
delay = ping3.ping(host)
if delay is not None:
    if delay < 50:
        network_status = "非常好"
    elif delay < 100:
        network_status = "良好"
    elif delay < 200:
        network_status = "中"
    elif delay < 500:
        network_status = "较大延迟"
    else:
        network_status = "非常不好"
else:
    network_status = "无法连接至服务器"
    exit

print(ANSIColors.GREEN + f"网络状态：{network_status}（{delay}）" + ANSIColors.RESET)

if delay > 500:
    print(ANSIColors.YELLOW + "您与服务器之间的连接状态不佳，可能会受影响。" + ANSIColors.RESET)

# 获取用户输入的 RCON 密码
password = input("输入 RCON 密码: ")

if not password:
    print(ANSIColors.YELLOW + "您正在尝试使用无密码方式登陆服务器" + ANSIColors.RESET)
    print(ANSIColors.YELLOW + "无密码方式登陆的服务器会存在一系列安全问题" + ANSIColors.RESET)
    print(ANSIColors.YELLOW + "如果你是服务器管理员，则你应该立即设置一个高强度密码" + ANSIColors.RESET)
    print(ANSIColors.YELLOW + "如果你不是服务器管理员，则你应该立即向管理员报告" + ANSIColors.RESET)

# 创建连接
rcon = mcrcon.MCRcon(host, password, port)
try:
    rcon.connect()
    print(ANSIColors.GREEN + "连接成功！" + ANSIColors.RESET)
    print("输入 connect off 终止连接")

    while True:
            command = input("> ")  # 获取用户输入的命令
            if command.lower() == "connect off":
                print(ANSIColors.GREEN + '已退出程序并终止连接' + ANSIColors.RESET)
                break  # 如果用户输入 connect off，则退出循环 
            response = rcon.command(command)  # 发送用户输入的命令到服务器并获取返回结果
            response = translate_colors(response)  # 将服务器返回的字符串中的 § 替换为 ANSI 转义码
            print(response + ANSIColors.RESET)  # 显示服务器返回的结果
finally:
    rcon.disconnect()  # 最终断开连接