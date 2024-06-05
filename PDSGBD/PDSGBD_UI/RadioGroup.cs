using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDSGBD.UI
{
    public partial class RadioGroup : UserControl
    {
        public static int MaximumItemCount => 50;

        private const int ItemMargin = 3;

        private const int HeightAdjustment = 3 * ItemMargin;

        private int m_ItemHeight;

        private List<object> m_Items;

        private List<RadioButton> m_RadioItems;

        public int Count => m_Items.Count;

        public object this[int index] => ((index >= 0) && (index < m_Items.Count)) ? m_Items[index] : null;

        public IEnumerable<object> Items => m_Items;

        private int m_CheckedIndex;

        public int CheckedIndex
        {
            get => m_CheckedIndex;
            set
            {
                if ((value < -1) || (value >= m_Items.Count)) return;
                if ((value >= 0) && !m_RadioItems[value].Enabled) return;
                if (value != m_CheckedIndex)
                {
                    if (value >= 0)
                    {
                        m_CheckedIndex = value;
                        m_RadioItems[m_CheckedIndex].Checked = true;
                    }
                    else
                    {
                        if (m_CheckedIndex >= 0) m_RadioItems[m_CheckedIndex].Checked = false;
                        m_CheckedIndex = -1;
                    }
                    OnCheckedItemChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public object CheckedItem
        {
            get => (m_CheckedIndex >= 0) ? m_Items[m_CheckedIndex] : null;
            set
            {
                CheckedIndex = m_Items.IndexOf(value);
            }
        }

        public event EventHandler OnCheckedItemChanged;

        public RadioGroup()
        {
            InitializeComponent();
            m_CheckedIndex = -1;
            m_Items = new List<object>();
            m_RadioItems = new List<RadioButton>();
            scrollBar.Minimum = 0;
            panelContainer.BackColor = BackColor;
            panelContainer.Padding = new Padding(0);
            tlpItems.Margin = new Padding(0);
            tlpItems.AutoSize = false;
            tlpItems.Dock = DockStyle.None;
            tlpItems.Location = new Point(0, 0);
            tlpItems.BackColor = BackColor;
            this.BackColorChanged += (s, e) =>
            {
                panelContainer.BackColor = BackColor;
                tlpItems.BackColor = BackColor;
            };
            this.ForeColorChanged += (s, e) =>
            {
                foreach (var radioItem in tlpItems.Controls.OfType<RadioButton>())
                {
                    radioItem.ForeColor = this.ForeColor;
                }
            };
            this.FontChanged += (s, e) =>
            {
                foreach (var radioItem in tlpItems.Controls.OfType<RadioButton>())
                {
                    radioItem.Font = this.Font;
                }
            };
            panelContainer.SizeChanged += (s, e) =>
            {
                tlpItems.Width = panelContainer.ClientSize.Width;
                UpdateScrollBar();
            };
            scrollBar.ValueChanged += (s, e) =>
            {
                tlpItems.Top = -scrollBar.Value;
            };
            ClearItems();
        }

        public void ClearItems()
        {
            tlpItems.Controls.Clear();
            m_Items.Clear();
            m_RadioItems.Clear();
            tlpItems.RowStyles.Clear();
            tlpItems.RowStyles.Add(new RowStyle(SizeType.Percent, 1f));
            tlpItems.RowCount = 1;
            tlpItems.Height = 0;
            UpdateScrollBar();
        }

        public bool AddItem(object item, bool state = true)
        {
            if (m_Items.Count == MaximumItemCount) return false;
            var itemIndex = m_Items.Count;
            var itemText = (item != null) ? item.ToString() : string.Empty;
            itemText = (itemText == null) ? string.Empty : itemText.Trim();
            var newRadioItem = new RadioButton()
            {
                Text = itemText,
                Checked = false,
                TextAlign = ContentAlignment.MiddleLeft,
                CheckAlign = ContentAlignment.MiddleLeft,
                BackColor = BackColor,
                Font = this.Font,
                ForeColor = this.ForeColor,
                Dock = DockStyle.Fill,
                AutoSize = true,
                Enabled = state,
                Visible = true,
                Margin = new Padding(ItemMargin),

            };
            newRadioItem.CheckedChanged += (s, e) =>
            {
                CheckedIndex = itemIndex;
            };
            tlpItems.RowCount++;
            tlpItems.RowStyles.Insert(itemIndex, new RowStyle(SizeType.AutoSize));
            tlpItems.Controls.Add(newRadioItem, 0, itemIndex);
            m_Items.Add(item);
            m_RadioItems.Add(newRadioItem);
            UpdateScrollBar();
            return true;
        }

        public bool EnableItem(int index, bool state = true)
        {
            if ((index < 0) || (index >= m_RadioItems.Count)) return false;
            m_RadioItems[index].Enabled = state;
            return true;
        }

        private void UpdateScrollBar()
        {
            var allItemsHeight = tlpItems.Controls.OfType<RadioButton>().Sum(radioItem => radioItem.Height + radioItem.Margin.Vertical);
            tlpItems.Size = new Size(panelContainer.ClientSize.Width, HeightAdjustment + allItemsHeight);
            var needScrollBar = (tlpItems.Height > panelContainer.ClientSize.Height);
            if (needScrollBar)
            {
                scrollBar.Maximum = (tlpItems.Height - panelContainer.ClientSize.Height);
                scrollBar.LargeChange = panelContainer.ClientSize.Height - allItemsHeight / m_Items.Count;
            }
            else
            {
                scrollBar.Value = 0;
            }
            scrollBar.Visible = needScrollBar;
        }
    }
}
