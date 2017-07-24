namespace VrachMedcentr
{
    class Appointments
    {
        /// <summary>
        ///  нужно поле для номера за порядком 
        /// </summary>
        /// 
        public string IDUser { get; set; }
        public int NumberZP { get; set; }
        public string Pacient { get; set; }
        public string TimeAppomination { get; set; }
        public string Comment { get; set; }
        public bool NotComing { get; set; }

    }
}
