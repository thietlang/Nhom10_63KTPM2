import ctypes

# Sử dụng kernel32.dll
kernel32 = ctypes.WinDLL('kernel32')

# Định nghĩa các hằng số từ thư viện Windows API
PAGE_READWRITE = 0x04
MEM_COMMIT = 0x1000
MEM_RESERVE = 0x2000
MEM_RELEASE = 0x8000  # Định nghĩa MEM_RELEASE

# Địa chỉ bắt đầu của bộ nhớ ảo
mem_address = 0x7ff00000  # Đây là một địa chỉ ảo tùy ý, bạn có thể chọn một địa chỉ khác

# Kích thước bộ nhớ cần cấp phát
mem_size = 1024  # Kích thước 1KB

# Cấp phát bộ nhớ ảo tại địa chỉ cụ thể
mem_ptr = kernel32.VirtualAlloc(mem_address, mem_size, MEM_RESERVE | MEM_COMMIT, PAGE_READWRITE)

if not mem_ptr:
    print("Không thể cấp phát bộ nhớ ảo")
else:
    print(f"Đã cấp phát {mem_size} byte bộ nhớ ảo tại địa chỉ {hex(mem_ptr)}")

# Giải phóng bộ nhớ ảo
kernel32.VirtualFree(mem_ptr, 0, MEM_RELEASE)
print(f"Đã giải phóng bộ nhớ ảo tại địa chỉ {hex(mem_ptr)}")

