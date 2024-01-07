using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class GameForm : Form
    {
        int xMeshSize;
        int yMeshSize;
        int numberOfVictims;
        int victimsReproductionAge;
        int victimsReproductionInterval;
        int numberOfPredators;
        int predatorsReproductionAge;
        int predatorsReproductionInterval;
        int predatorCanStarve;
        Creature[,] creatures;
        int TactsCount;
        Random r;
        public GameForm(int xMeshSize, int yMeshSize, int numberOfVictims, int victimsReproductionAge, int victimsReproductionInterval, int numberOfPredators, int predatorsReproductionAge, int predatorsReproductionInterval, int predatorCanStarve)
        {
            InitializeComponent();
            this.xMeshSize = xMeshSize;
            this.yMeshSize = yMeshSize;
            this.numberOfVictims = numberOfVictims;
            this.victimsReproductionAge = victimsReproductionAge;
            this.victimsReproductionInterval = victimsReproductionInterval;
            this.numberOfPredators = numberOfPredators;
            this.predatorsReproductionAge = predatorsReproductionAge;
            this.predatorsReproductionInterval = predatorsReproductionInterval;
            this.predatorCanStarve = predatorCanStarve;
            creatures = new Creature[yMeshSize, xMeshSize];
            r = new Random();
            TactsCount = 1;
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            InitCreatures();
            SetCreaturesPositions();
            pondDataGridView.DataSource = ConvertArrayOfCreaturesToDataTable(creatures);
            SetPondDataGridViewData();
            pondDataGridView.ClearSelection();
            tactsCountLabel.Text ="Tact - " + TactsCount.ToString();
            timer1.Start();
        }

        private void InitCreatures()
        {
            int victimsInArray = 0;
            int predatorsInArray = 0;
            for (int i = 0; i < creatures.GetLength(0); i++)
            {
                for (int j = 0; j < creatures.GetLength(1); j++)
                {
                    if (victimsInArray >= numberOfVictims)
                    {
                        if (predatorsInArray >= numberOfPredators)
                            break;
                        creatures[i, j] = new Predator(predatorsReproductionAge, predatorsReproductionInterval, predatorCanStarve, r.Next(0, predatorsReproductionAge),new CreaturePosition(j,i),r);
                        predatorsInArray++;
                    }
                    else
                    {
                        creatures[i, j] = new Victim(victimsReproductionAge, victimsReproductionInterval, r.Next(0, victimsReproductionAge), new CreaturePosition(j, i), r);
                        victimsInArray++;
                    }
                }
            }
        }

        private void SetCreaturesPositions()
        {
            Creature[,] newCreatures = new Creature[creatures.GetLength(0),creatures.GetLength(1)];
            newCreatures = (Creature[,])creatures.Clone();
            for (int i = 0; i < creatures.GetLength(0); i++)
            {
                for (int j = 0; j < creatures.GetLength(1); j++)
                {
                    if (creatures[i, j] != null)
                        newCreatures = (Creature[,])newCreatures[i, j].SetCreaturePosition(newCreatures).Clone();
                }
            }
            creatures = (Creature[,])newCreatures.Clone();
        }

        private void SetPondDataGridViewData()
        {
            int rowIndexToDisplay = pondDataGridView.FirstDisplayedScrollingRowIndex;
            int columnIndexToDisplay = pondDataGridView.FirstDisplayedScrollingColumnIndex;
            pondDataGridView.DataSource = ConvertArrayOfCreaturesToDataTable(creatures);            
            pondDataGridView = PondFormat(pondDataGridView);            
            SetPondDataGridViewCellsSize();            
            pondDataGridView.FirstDisplayedScrollingRowIndex = rowIndexToDisplay;
            pondDataGridView.FirstDisplayedScrollingColumnIndex = columnIndexToDisplay;
        }        

        private void SetPondDataGridViewCellsSize()
        {
            foreach (DataGridViewColumn column in pondDataGridView.Columns)
            {
                column.Width = 10;                    
            }            
            foreach (DataGridViewRow row in pondDataGridView.Rows)
            {
                row.Height = 10;
            }
        }
        private DataGridView PondFormat(DataGridView dgv)
        {
            
            for (int i = 0; i < dgv.Rows.Count; i++) 
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    if (dgv[j, i].Value != DBNull.Value)
                    {
                        dgv[j, i].Style.BackColor = ((Creature)dgv[j, i].Value).CreatureColor;
                        dgv[j, i].Style.ForeColor = ((Creature)dgv[j, i].Value).CreatureColor;
                    }
                }
            }
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            return dgv;
        }

        private DataTable ConvertArrayOfCreaturesToDataTable(Creature[,] creatures )
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < creatures.GetLength(1); i++)
            {
                dt.Columns.Add();
                dt.Columns[i].DataType = typeof(Creature);
            }
            for (int i = 0; i < creatures.GetLength(0); i++)
            {
                dt.Rows.Add();                
            }            
            for (int i = 0; i < creatures.GetLength(0); i++)
            {
                for (int j = 0; j < creatures.GetLength(1); j++)
                {
                    dt.Rows[i][j] = creatures[i, j];                    
                }
            }
            return dt;
        }

        private void ChangeVictimsPositions()
        {
            Creature[,] newCreatures = new Creature[creatures.GetLength(0), creatures.GetLength(1)];
            newCreatures = (Creature[,])creatures.Clone();
            for (int i = 0; i < creatures.GetLength(0); i++)
            {
                for (int j = 0; j < creatures.GetLength(1); j++)
                {
                    if (creatures[i, j] != null && creatures[i, j].GetType() == typeof(Victim))
                        newCreatures = (Creature[,])newCreatures[i, j].ChangeCreaturePosition(newCreatures).Clone();
                }
            }
            creatures = (Creature[,])newCreatures.Clone();
        }

        private void ChangePredatorsPositions()
        {
            Creature[,] newCreatures = new Creature[creatures.GetLength(0), creatures.GetLength(1)];
            newCreatures = (Creature[,])creatures.Clone();
            for (int i = 0; i < creatures.GetLength(0); i++)
            {
                for (int j = 0; j < creatures.GetLength(1); j++)
                {
                    if (creatures[i, j] != null && creatures[i, j].GetType() == typeof(Predator))
                        newCreatures = (Creature[,])newCreatures[i, j].ChangeCreaturePosition(newCreatures).Clone();
                }
            }
            creatures = (Creature[,])newCreatures.Clone();
        }

        private void ChangeCreaturesPositions()
        {
            ChangeVictimsPositions();
            ChangePredatorsPositions();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ChangeCreaturesPositions();
            SetPondDataGridViewData();
            TactsCount++;
            tactsCountLabel.Text = "Tact - " + TactsCount.ToString();
        }

        private void pondDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            pondDataGridView.ClearSelection();
        }

        private void GameForm_SizeChanged(object sender, EventArgs e)
        {
            SetPondDataGridViewCellsSize();
        }

        private void stopTimerButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void startTimerButton_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
