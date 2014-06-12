// Developed by Riketta https://github.com/Riketta/Stronghold-Kingdoms-Bot


namespace BotDLL
{
    partial class BotForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BotForm));
            this.listBox_ResList = new System.Windows.Forms.ListBox();
            this.textBox_TradeTargetID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Trade = new System.Windows.Forms.Button();
            this.button_MapEditing = new System.Windows.Forms.Button();
            this.richTextBox_In = new System.Windows.Forms.RichTextBox();
            this.button_Exec = new System.Windows.Forms.Button();
            this.richTextBox_Out = new System.Windows.Forms.RichTextBox();
            this.richTextBox_Log = new System.Windows.Forms.RichTextBox();
            this.textBox_ResCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Admin = new System.Windows.Forms.Button();
            this.listBox_ResearchList = new System.Windows.Forms.ListBox();
            this.listBox_Queue = new System.Windows.Forms.ListBox();
            this.button_FreeCardAutoLoot = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_CurrentResearch = new System.Windows.Forms.TextBox();
            this.button_CancelResearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox_ResList
            // 
            this.listBox_ResList.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox_ResList.FormattingEnabled = true;
            this.listBox_ResList.Items.AddRange(new object[] {
            "6 - Wood",
            "7 - Stone",
            "8 - Iron",
            "9 - Pitch",
            "12 - Ale",
            "13 - Apples",
            "14 - Bread",
            "15 - Veg",
            "16 - Meat",
            "17 - Cheese",
            "18 - Fish",
            "19 - Clothes",
            "21 - Furniture",
            "22 - Venison",
            "23 - Salt",
            "24 - Spices",
            "25 - Salt",
            "26 - Metalware",
            "28 - Pikes",
            "29 - Bows",
            "30 - Swords",
            "31 - Armour",
            "32 - Catapults",
            "33 - Wine"});
            this.listBox_ResList.Location = new System.Drawing.Point(0, 0);
            this.listBox_ResList.Name = "listBox_ResList";
            this.listBox_ResList.Size = new System.Drawing.Size(86, 381);
            this.listBox_ResList.TabIndex = 0;
            this.listBox_ResList.SelectedIndexChanged += new System.EventHandler(this.listBox_ResList_SelectedIndexChanged);
            // 
            // textBox_TradeTargetID
            // 
            this.textBox_TradeTargetID.Location = new System.Drawing.Point(140, 6);
            this.textBox_TradeTargetID.Name = "textBox_TradeTargetID";
            this.textBox_TradeTargetID.Size = new System.Drawing.Size(58, 20);
            this.textBox_TradeTargetID.TabIndex = 1;
            this.textBox_TradeTargetID.Text = "52792";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID цели:";
            // 
            // button_Trade
            // 
            this.button_Trade.Location = new System.Drawing.Point(383, 4);
            this.button_Trade.Name = "button_Trade";
            this.button_Trade.Size = new System.Drawing.Size(75, 23);
            this.button_Trade.TabIndex = 3;
            this.button_Trade.Text = "Торговать";
            this.button_Trade.UseVisualStyleBackColor = true;
            this.button_Trade.Click += new System.EventHandler(this.button_Trade_Click);
            // 
            // button_MapEditing
            // 
            this.button_MapEditing.Location = new System.Drawing.Point(383, 84);
            this.button_MapEditing.Name = "button_MapEditing";
            this.button_MapEditing.Size = new System.Drawing.Size(75, 23);
            this.button_MapEditing.TabIndex = 4;
            this.button_MapEditing.Text = "MapEditing";
            this.button_MapEditing.UseVisualStyleBackColor = true;
            this.button_MapEditing.Click += new System.EventHandler(this.button_MapEditing_Click);
            // 
            // richTextBox_In
            // 
            this.richTextBox_In.Location = new System.Drawing.Point(92, 115);
            this.richTextBox_In.Name = "richTextBox_In";
            this.richTextBox_In.Size = new System.Drawing.Size(366, 100);
            this.richTextBox_In.TabIndex = 5;
            this.richTextBox_In.Text = "";
            // 
            // button_Exec
            // 
            this.button_Exec.Location = new System.Drawing.Point(92, 277);
            this.button_Exec.Name = "button_Exec";
            this.button_Exec.Size = new System.Drawing.Size(366, 26);
            this.button_Exec.TabIndex = 6;
            this.button_Exec.Text = "Выполнить код";
            this.button_Exec.UseVisualStyleBackColor = true;
            this.button_Exec.Click += new System.EventHandler(this.button_Exec_Click);
            // 
            // richTextBox_Out
            // 
            this.richTextBox_Out.Location = new System.Drawing.Point(92, 221);
            this.richTextBox_Out.Name = "richTextBox_Out";
            this.richTextBox_Out.ReadOnly = true;
            this.richTextBox_Out.Size = new System.Drawing.Size(366, 50);
            this.richTextBox_Out.TabIndex = 7;
            this.richTextBox_Out.Text = "";
            // 
            // richTextBox_Log
            // 
            this.richTextBox_Log.Location = new System.Drawing.Point(92, 308);
            this.richTextBox_Log.Name = "richTextBox_Log";
            this.richTextBox_Log.ReadOnly = true;
            this.richTextBox_Log.Size = new System.Drawing.Size(366, 70);
            this.richTextBox_Log.TabIndex = 8;
            this.richTextBox_Log.Text = "";
            // 
            // textBox_ResCount
            // 
            this.textBox_ResCount.Location = new System.Drawing.Point(309, 6);
            this.textBox_ResCount.Name = "textBox_ResCount";
            this.textBox_ResCount.Size = new System.Drawing.Size(68, 20);
            this.textBox_ResCount.TabIndex = 9;
            this.textBox_ResCount.Text = "1000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Кол-во на трейдера:";
            // 
            // button_Admin
            // 
            this.button_Admin.Location = new System.Drawing.Point(302, 84);
            this.button_Admin.Name = "button_Admin";
            this.button_Admin.Size = new System.Drawing.Size(75, 23);
            this.button_Admin.TabIndex = 11;
            this.button_Admin.Text = "Admin";
            this.button_Admin.UseVisualStyleBackColor = true;
            this.button_Admin.Click += new System.EventHandler(this.button_Admin_Click);
            // 
            // listBox_ResearchList
            // 
            this.listBox_ResearchList.FormattingEnabled = true;
            this.listBox_ResearchList.Items.AddRange(new object[] {
            "61 - Animal Husbandry - Животноводство",
            "33 - Architecture - Архитектура",
            "17 - Armour Working - Произв. доспехов",
            "43 - Armoury Capacity - Вмест. оружейной",
            "59 - Arts - Искусство",
            "12 - Bakery - Выпечка",
            "55 - Baptism - Крещение",
            "15 - Black Smithing - Кузнечное дело",
            "81 - Bounties - Вознаграждение",
            "10 - Brewing - Пивоварение",
            "11 - Butchery - Скотобойня",
            "79 - CAP_Ballista",
            "77 - CAP_Tunnellors",
            "31 - CAP_Turrets",
            "25 - Captains - Капитаны",
            "8 - Carpentry - Плотничное дело",
            "19 - Castellation - Сооружение замков",
            "26 - Catapult - Катапульты",
            "83 - Civil Service - Госслужба",
            "24 - Command - Командование",
            "35 - Commerce - Коммерция",
            "51 - Confession - Исповедь",
            "54 - Confirmation - Миропомазание",
            "30 - Conscription - Воин. повинность",
            "20 - Construction - Строительство",
            "80 - Counter Surveillance - Контрразведка",
            "82 - Courtiers",
            "6 - Craftsmanship - Логистика?",
            "64 - Dairy Farming - Молочное с/х",
            "21 - Defences - Оборона",
            "57 - Diplomacy - Дипломатия",
            "40 - Engineering - Инженерия",
            "31 - Espionage - Шпионаж",
            "53 - Eucharist - Евхаристия",
            "50 - Extreme Unction - Соборование",
            "65 - Fishing - Рыболовство",
            "18 - Fletching - Произв. луков",
            "37 - Foraging - Сбор ресурсов",
            "86 - Forced March - Марш-бросок",
            "1 - Forestry - Лесная промышл.",
            "23 - Fortification - Фортификации",
            "60 - Gardening",
            "45 - Granary Capacity - Вмест. амбара",
            "41 - Hall Capacity - Вмест. общин. дома",
            "67 - Hops Farming - Хмелеводство",
            "76 - Horsemanship - Верховая езда",
            "42 - Housing Capacity - Вмест. хижин",
            "63 - Hunting - Охота",
            "44 - Inn Capacity - Вмест. трактира",
            "79 - Intelligence - Разведка",
            "2 - Iron Mining - Добыча железа",
            "58 - Justice - Правосудие",
            "36 - LandTrade",
            "74 - Leadership - Лидерство",
            "47 - Literature - Литература",
            "29 - Long Bow - Длинный лук",
            "56 - Marriage - Помолвка",
            "32 - Mathematics - Математика",
            "34 - Merchant Guilds - Гильдии торговцев",
            "9 - Metal Bashing - Произв. посуды",
            "66 - Orchard Management - Управление садом",
            "52 - Ordination - Посвящение",
            "48 - Philosophy - Философия",
            "62 - Pig Breeding - Свиноводство",
            "28 - Pike - Пика",
            "72 - Pilgrimage - Паломничество",
            "78 - Pillaging - Набег",
            "3 - Pitch Extraction - Добыча смолы",
            "68 - Plough - Плуг",
            "16 - Poleturning - Пикодельня",
            "85 - Ransacking - Поджог",
            "84 - Sally Forth - Вылазка",
            "5 - Salt Working - Добыча соли",
            "75 - Scouts - Разведчики",
            "14 - Siege Mechanics - Осадные орудия",
            "38 - Silk Trade - Торговля шелком",
            "39 - Spice Trade - Торговля специями",
            "46 - Stockpile Capacity - Вмест. склада",
            "0 - Stone Quarrying - Добыча камня",
            "77 - Surveillance - Разведка",
            "27 - Sword - Меч",
            "73 - Tactics - Тактики",
            "7 - Tailoring - Портняжное дело",
            "49 - Theology - Богословие",
            "4 - Tools - Инструменты",
            "22 - Vaults - Подвалы",
            "71 - Vegetable Cropping - Сбор овощей",
            "13 - Weapon Making - Произв. оружия",
            "70 - Wheat Production - Произв. пшеницы",
            "69 - Wine Production - Произв. вина"});
            this.listBox_ResearchList.Location = new System.Drawing.Point(469, 1);
            this.listBox_ResearchList.Name = "listBox_ResearchList";
            this.listBox_ResearchList.Size = new System.Drawing.Size(235, 303);
            this.listBox_ResearchList.TabIndex = 13;
            this.listBox_ResearchList.SelectedIndexChanged += new System.EventHandler(this.listBox_ResearchList_SelectedIndexChanged);
            // 
            // listBox_Queue
            // 
            this.listBox_Queue.FormattingEnabled = true;
            this.listBox_Queue.Location = new System.Drawing.Point(469, 308);
            this.listBox_Queue.Name = "listBox_Queue";
            this.listBox_Queue.Size = new System.Drawing.Size(235, 69);
            this.listBox_Queue.TabIndex = 14;
            this.listBox_Queue.SelectedIndexChanged += new System.EventHandler(this.listBox_Queue_SelectedIndexChanged);
            // 
            // button_FreeCardAutoLoot
            // 
            this.button_FreeCardAutoLoot.Location = new System.Drawing.Point(92, 84);
            this.button_FreeCardAutoLoot.Name = "button_FreeCardAutoLoot";
            this.button_FreeCardAutoLoot.Size = new System.Drawing.Size(118, 23);
            this.button_FreeCardAutoLoot.TabIndex = 15;
            this.button_FreeCardAutoLoot.Text = "AutoLoot Enabled";
            this.button_FreeCardAutoLoot.UseVisualStyleBackColor = true;
            this.button_FreeCardAutoLoot.Click += new System.EventHandler(this.button_FreeCardAutoLoot_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Текущее исследование:";
            // 
            // textBox_CurrentResearch
            // 
            this.textBox_CurrentResearch.Location = new System.Drawing.Point(228, 37);
            this.textBox_CurrentResearch.Name = "textBox_CurrentResearch";
            this.textBox_CurrentResearch.ReadOnly = true;
            this.textBox_CurrentResearch.Size = new System.Drawing.Size(154, 20);
            this.textBox_CurrentResearch.TabIndex = 17;
            this.textBox_CurrentResearch.Text = "None";
            // 
            // button_CancelResearch
            // 
            this.button_CancelResearch.Location = new System.Drawing.Point(388, 35);
            this.button_CancelResearch.Name = "button_CancelResearch";
            this.button_CancelResearch.Size = new System.Drawing.Size(75, 23);
            this.button_CancelResearch.TabIndex = 18;
            this.button_CancelResearch.Text = "Прервать";
            this.button_CancelResearch.UseVisualStyleBackColor = true;
            // 
            // BotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 381);
            this.Controls.Add(this.button_CancelResearch);
            this.Controls.Add(this.textBox_CurrentResearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_FreeCardAutoLoot);
            this.Controls.Add(this.listBox_Queue);
            this.Controls.Add(this.listBox_ResearchList);
            this.Controls.Add(this.button_Admin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_ResCount);
            this.Controls.Add(this.richTextBox_Log);
            this.Controls.Add(this.richTextBox_Out);
            this.Controls.Add(this.button_Exec);
            this.Controls.Add(this.richTextBox_In);
            this.Controls.Add(this.button_MapEditing);
            this.Controls.Add(this.button_Trade);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_TradeTargetID);
            this.Controls.Add(this.listBox_ResList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BotForm";
            this.Text = "Bot Control";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BotForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_ResList;
        private System.Windows.Forms.TextBox textBox_TradeTargetID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Trade;
        private System.Windows.Forms.Button button_MapEditing;
        private System.Windows.Forms.RichTextBox richTextBox_In;
        private System.Windows.Forms.Button button_Exec;
        private System.Windows.Forms.RichTextBox richTextBox_Out;
        private System.Windows.Forms.RichTextBox richTextBox_Log;
        private System.Windows.Forms.TextBox textBox_ResCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Admin;
        private System.Windows.Forms.ListBox listBox_ResearchList;
        private System.Windows.Forms.ListBox listBox_Queue;
        private System.Windows.Forms.Button button_FreeCardAutoLoot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_CurrentResearch;
        private System.Windows.Forms.Button button_CancelResearch;
    }
}