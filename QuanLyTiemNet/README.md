# Phần mềm Quản Lý Tiệm Net (Net Management System)

Một ứng dụng Windows Forms phát triển trên nền tảng .NET Framework và ngôn ngữ C#, sử dụng cơ sở dữ liệu SQL Server để quản lý và vận hành tiệm net/Cyber Game một cách chuyên nghiệp và hiệu quả.

---

## 📌 Các Tính Năng Chính

Ứng dụng hỗ trợ phân quyền người dùng thành 3 vai trò chính với các chức năng chuyên biệt:

### 1. Phân Hệ Đăng Nhập & Tài Khoản (`Login`, `Register`, `ForgotPassword`)
*   Đăng nhập hệ thống bảo mật bằng số điện thoại và mật khẩu.
*   Đăng ký tài khoản mới cho nhân viên/khách hàng.
*   Khôi phục mật khẩu thông qua form Quên mật khẩu.

### 2. Phân Hệ Nhân Viên Phục Vụ (`Staff`)
*   **Quản lý sơ đồ máy**: Hiển thị trực quan trạng thái hoạt động của toàn bộ máy trạm trong phòng net (Màu xanh: Chưa sử dụng, Màu đỏ: Đang sử dụng).
*   **Mở máy & Nạp tiền**: Kích hoạt máy mới và nạp giờ chơi dựa trên số tiền nạp (tỷ lệ quy đổi ví dụ: 100đ = 1 phút).
*   **Gia hạn giờ chơi**: Cộng thêm thời gian sử dụng cho máy đang hoạt động.
*   **Quản lý dịch vụ đi kèm**: Gọi đồ ăn, thức uống (thêm dịch vụ mới, cập nhật số lượng hoặc xóa món ăn khỏi hóa đơn).
*   **Hủy phiên sử dụng**: Hủy bàn/máy đang hoạt động trong trường hợp cần thiết.
*   **Thanh toán & In hóa đơn**: Tính tổng tiền dịch vụ và giờ chơi, in chi tiết hóa đơn thanh toán và lưu lịch sử.

### 3. Phân Hệ Thu Ngân (`Cashier` & `Payment`)
*   Xem danh sách các giao dịch và hóa đơn thanh toán trong hệ thống.
*   Tìm kiếm nhanh thông tin đơn hàng/dịch vụ theo mã đơn.
*   Lọc dữ liệu hóa đơn theo ngày thông qua bộ chọn ngày (`DateTimePicker`).

### 4. Phân Hệ Chủ Tiệm/Quản Trị Viên (`Admin`)
*   Theo dõi doanh thu và lịch sử đơn hàng của quán.
*   Tích hợp các báo cáo thanh toán trực quan.

---

## 🛠️ Công Nghệ Sử Dụng

*   **Ngôn ngữ lập trình**: C# (.NET Framework)
*   **Giao diện**: Windows Forms (WinForms) với thiết kế tùy biến, bo tròn TextBox, hiệu ứng rê chuột (Hover) trực quan.
*   **Cơ sở dữ liệu**: SQL Server.
*   **Tương tác dữ liệu**: ADO.NET (Sử dụng `SqlConnection`, `SqlCommand`, `SqlParameter`, `SqlDataAdapter` để gọi Store Procedure và Function nhằm tối ưu hiệu năng và bảo mật SQL Injection).

---

## 💾 Cấu Trúc Cơ Sở Dữ Liệu & Stored Procedures

Hệ thống giao tiếp trực tiếp với cơ sở dữ liệu `NET` qua các hàm và thủ tục:
*   `DangNhap`: Hàm xác thực tài khoản và trả về vai trò người dùng.
*   `LayThongTin`: Thủ tục lấy thông tin chi tiết của nhân viên/người dùng.
*   `KiemTraTinhTrangMayTinh`: Kiểm tra trạng thái máy là `ChuaSuDung` hay `DangSuDung`.
*   `NapTienLanDau`: Thủ tục mở máy và nạp giờ chơi lần đầu.
*   `GiaHanMayTinh`: Thủ tục cộng thêm giờ chơi.
*   `ThemDichVuKhac`: Thủ tục gọi thêm món ăn/nước uống cho máy.
*   `CapNhatSanPham` & `XoaDuLieu`: Điều chỉnh/xóa dịch vụ đi kèm.
*   `TaoHoaDon`: Lưu trữ và tạo hóa đơn thanh toán.
*   `TimKiemDonHang` & `LocDuLieu`: Hỗ trợ thu ngân tra cứu thông tin hóa đơn.

---

## 🚀 Hướng Dẫn Cài Đặt & Chạy Dự Án

### Yêu Cầu Hệ Thống
*   Microsoft Visual Studio (Khuyến nghị bản 2019 hoặc mới hơn).
*   Microsoft SQL Server & SQL Server Management Studio (SSMS).
*   .NET Framework phù hợp với dự án.

### Các Bước Thực Hiện
1.  **Cài đặt Cơ sở dữ liệu**:
    *   Mở SQL Server và tạo một cơ sở dữ liệu mới tên là `NET`.
    *   Chạy các script tạo bảng, hàm (Functions) và thủ tục lưu trữ (Stored Procedures) tương ứng.
2.  **Cấu hình Kết nối**:
    *   Mở file [DatabaseConnection.cs](file:///c:/Users/HAI/Downloads/LeVuHai/QuanLyTiemNet/QuanLyTiemNet/DatabaseConnection.cs).
    *   Chỉnh sửa chuỗi kết nối (`connection`) cho khớp với SQL Server instance của bạn:
        ```csharp
        public string connection = "Data Source=TEN_MAY_TINH;Initial Catalog=NET;User ID=sa;Password=MAT_KHAU";
        ```
3.  **Build & Run**:
    *   Mở file solution `QuanLyTiemNet.sln` hoặc project [QuanLyTiemNet.csproj](file:///c:/Users/HAI/Downloads/LeVuHai/QuanLyTiemNet/QuanLyTiemNet/QuanLyTiemNet.csproj) bằng Visual Studio.
    *   Nhấn `F5` hoặc nút `Start` để chạy ứng dụng. Giao diện Đăng nhập sẽ hiện ra đầu tiên.
