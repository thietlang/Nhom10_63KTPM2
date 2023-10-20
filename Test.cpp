#include <windows.h>
#include <stdio.h>
int main() {
    HANDLE hFile;
    DWORD bytesWritten;
    DWORD bytesRead;
    char buffer[256];
    //  Tao mot tep tin
    hFile = CreateFileW(L"NewFile.txt", GENERIC_WRITE | GENERIC_READ, 0, NULL, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);
    if (hFile == INVALID_HANDLE_VALUE) {
        perror("Loi khi tao mot tep tin");
        return 1;
    }
    //  Viet du lieu vao tep tin
    const char data[] = "I am a student at the University of Thuy Loi ";
    if (!WriteFile(hFile, data, sizeof(data), &bytesWritten, NULL)) {
        perror("Loi khi ghi du lieu vao tep tin");
        CloseHandle(hFile);
        return 1;
    }
    //  Doc du lieu tu tep tin
    SetFilePointer(hFile, 0, NULL, FILE_BEGIN); // Ðua con tro tep ve dau tep
    if (ReadFile(hFile, buffer, sizeof(buffer), &bytesRead, NULL)) {
        buffer[bytesRead] = '\0';  // Dam bao chuoi null-terminated
        printf("Noi dung tep tin: %s\n", buffer);
    } else {
        perror("Loi khi doc du lieu tu tep tin");
    }
    //  Dong tep tin
    CloseHandle(hFile);
    
    return 0;
}


