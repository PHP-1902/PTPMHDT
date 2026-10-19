
#nullable enable

using System;

namespace EduHub.Ch01.Domain
{
    /// <summary>
    /// Đại diện cho một sự kiện do câu lạc bộ tổ chức.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// Mã định danh duy nhất của sự kiện.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Mã định danh câu lạc bộ tổ chức sự kiện.
        /// </summary>
        public Guid ClubId { get; private set; }

        /// <summary>
        /// Tiêu đề sự kiện.
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Thời gian diễn ra sự kiện.
        /// </summary>
        public DateTime Date { get; private set; }

        /// <summary>
        /// Số lượng người tham gia tối đa.
        /// </summary>
        public int Capacity { get; private set; }

        /// <summary>
        /// Cho biết sự kiện có tổ chức trực tuyến hay không.
        /// </summary>
        public bool IsOnline { get; private set; }

        private Event(
            Guid id,
            Guid clubId,
            string title,
            DateTime date,
            int capacity,
            bool isOnline)
        {
            Id = id;
            ClubId = clubId;
            Title = title;
            Date = date;
            Capacity = capacity;
            IsOnline = isOnline;
        }

        /// <summary>
        /// Tạo sự kiện mới sau khi kiểm tra dữ liệu đầu vào.
        /// </summary>
        public static Event Create(
            Guid clubId,
            string title,
            DateTime date,
            int capacity,
            bool isOnline)
        {
            if (clubId == Guid.Empty)
                throw new ArgumentException(
                    "ClubId không được để trống.", nameof(clubId));

            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException(
                    "Tiêu đề sự kiện không được để trống.", nameof(title));

            if (date == default)
                throw new ArgumentException(
                    "Ngày sự kiện không hợp lệ.", nameof(date));

            if (capacity <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(capacity), "Capacity phải lớn hơn 0.");

            return new Event(
                Guid.NewGuid(),
                clubId,
                title.Trim(),
                date,
                capacity,
                isOnline);
        }

        /// <summary>
        /// Kiểm tra sự kiện còn chỗ cho người đăng ký hay không.
        /// </summary>
        public bool HasCapacity(int registeredCount)
        {
            if (registeredCount < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(registeredCount),
                    "Số người đăng ký không được âm.");

            return registeredCount < Capacity;
        }
    }
}
