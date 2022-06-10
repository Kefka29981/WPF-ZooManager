#pragma warning disable 1591

namespace WPF_ZooManager
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="PanjutorialsDB")]
	public partial class LinqToSqlDataClassesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Определения метода расширяемости
    partial void OnCreated();
    partial void InsertAnimal(Animal instance);
    partial void UpdateAnimal(Animal instance);
    partial void DeleteAnimal(Animal instance);
    partial void InsertZoos(Zoos instance);
    partial void UpdateZoos(Zoos instance);
    partial void DeleteZoos(Zoos instance);
    partial void InsertZooAnimal(ZooAnimal instance);
    partial void UpdateZooAnimal(ZooAnimal instance);
    partial void DeleteZooAnimal(ZooAnimal instance);
    #endregion
		
		public LinqToSqlDataClassesDataContext() : 
				base(global::WPF_ZooManager.Properties.Settings.Default.PanjutorialsDBConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public LinqToSqlDataClassesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LinqToSqlDataClassesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LinqToSqlDataClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LinqToSqlDataClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Animal> Animals
		{
			get
			{
				return this.GetTable<Animal>();
			}
		}
		
		public System.Data.Linq.Table<Zoos> Zoos
		{
			get
			{
				return this.GetTable<Zoos>();
			}
		}
		
		public System.Data.Linq.Table<ZooAnimal> ZooAnimal
		{
			get
			{
				return this.GetTable<ZooAnimal>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Animal")]
	public partial class Animal : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Name;
		
		private EntitySet<ZooAnimal> _ZooAnimals;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    #endregion
		
		public Animal()
		{
			this._ZooAnimals = new EntitySet<ZooAnimal>(new Action<ZooAnimal>(this.attach_ZooAnimals), new Action<ZooAnimal>(this.detach_ZooAnimals));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Animal_ZooAnimal", Storage="_ZooAnimals", ThisKey="Id", OtherKey="AnimalId")]
		public EntitySet<ZooAnimal> ZooAnimals
		{
			get
			{
				return this._ZooAnimals;
			}
			set
			{
				this._ZooAnimals.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_ZooAnimals(ZooAnimal entity)
		{
			this.SendPropertyChanging();
			entity.Animal = this;
		}
		
		private void detach_ZooAnimals(ZooAnimal entity)
		{
			this.SendPropertyChanging();
			entity.Animal = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Zoo")]
	public partial class Zoos : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Location;
		
		private EntitySet<ZooAnimal> _ZooAnimals;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnLocationChanging(string value);
    partial void OnLocationChanged();
    #endregion
		
		public Zoos()
		{
			this._ZooAnimals = new EntitySet<ZooAnimal>(new Action<ZooAnimal>(this.attach_ZooAnimals), new Action<ZooAnimal>(this.detach_ZooAnimals));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Location", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Location
		{
			get
			{
				return this._Location;
			}
			set
			{
				if ((this._Location != value))
				{
					this.OnLocationChanging(value);
					this.SendPropertyChanging();
					this._Location = value;
					this.SendPropertyChanged("Location");
					this.OnLocationChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Zoo_ZooAnimal", Storage="_ZooAnimals", ThisKey="Id", OtherKey="ZooID")]
		public EntitySet<ZooAnimal> ZooAnimals
		{
			get
			{
				return this._ZooAnimals;
			}
			set
			{
				this._ZooAnimals.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_ZooAnimals(ZooAnimal entity)
		{
			this.SendPropertyChanging();
			entity.Zoos = this;
		}
		
		private void detach_ZooAnimals(ZooAnimal entity)
		{
			this.SendPropertyChanging();
			entity.Zoos = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ZooAnimal")]
	public partial class ZooAnimal : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _ZooID;
		
		private int _AnimalId;
		
		private EntityRef<Animal> _Animal;
		
		private EntityRef<Zoos> _Zoo;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnZooIDChanging(int value);
    partial void OnZooIDChanged();
    partial void OnAnimalIdChanging(int value);
    partial void OnAnimalIdChanged();
    #endregion
		
		public ZooAnimal()
		{
			this._Animal = default(EntityRef<Animal>);
			this._Zoo = default(EntityRef<Zoos>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="ZooID", Storage="_ZooID", DbType="Int NOT NULL")]
		public int ZooID
		{
			get
			{
				return this._ZooID;
			}
			set
			{
				if ((this._ZooID != value))
				{
					this.OnZooIDChanging(value);
					this.SendPropertyChanging();
					this._ZooID = value;
					this.SendPropertyChanged("ZooID");
					this.OnZooIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AnimalId", DbType="Int NOT NULL")]
		public int AnimalId
		{
			get
			{
				return this._AnimalId;
			}
			set
			{
				if ((this._AnimalId != value))
				{
					if (this._Animal.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnAnimalIdChanging(value);
					this.SendPropertyChanging();
					this._AnimalId = value;
					this.SendPropertyChanged("AnimalId");
					this.OnAnimalIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Animal_ZooAnimal", Storage="_Animal", ThisKey="AnimalId", OtherKey="Id", IsForeignKey=true, DeleteOnNull=true, DeleteRule="CASCADE")]
		public Animal Animal
		{
			get
			{
				return this._Animal.Entity;
			}
			set
			{
				Animal previousValue = this._Animal.Entity;
				if (((previousValue != value) 
							|| (this._Animal.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Animal.Entity = null;
						previousValue.ZooAnimals.Remove(this);
					}
					this._Animal.Entity = value;
					if ((value != null))
					{
						value.ZooAnimals.Add(this);
						this._AnimalId = value.Id;
					}
					else
					{
						this._AnimalId = default(int);
					}
					this.SendPropertyChanged("Animal");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Zoo_ZooAnimal", Storage="_Zoo", ThisKey="ZooID", OtherKey="Id", IsForeignKey=true, DeleteOnNull=true, DeleteRule="CASCADE")]
		public Zoos Zoos
		{
			get
			{
				return this._Zoo.Entity;
			}
			set
			{
				Zoos previousValue = this._Zoo.Entity;
				if (((previousValue != value) 
							|| (this._Zoo.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Zoo.Entity = null;
						previousValue.ZooAnimals.Remove(this);
					}
					this._Zoo.Entity = value;
					if ((value != null))
					{
						value.ZooAnimals.Add(this);
						this._ZooID = value.Id;
					}
					else
					{
						this._ZooID = default(int);
					}
					this.SendPropertyChanged("Zoos");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
