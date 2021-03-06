//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

namespace Shopnet.Models
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(DetailPurchase))]
    [KnownType(typeof(DetailSale))]
    [KnownType(typeof(CartItem))]
    public partial class Product: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int ProductID
        {
            get { return _productID; }
            set
            {
                if (_productID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'ProductID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _productID = value;
                    OnPropertyChanged("ProductID");
                }
            }
        }
        private int _productID;
    
        [DataMember]
        public string Code
        {
            get { return _code; }
            set
            {
                if (_code != value)
                {
                    _code = value;
                    OnPropertyChanged("Code");
                }
            }
        }
        private string _code;
    
        [DataMember]
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        private string _name;
    
        [DataMember]
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        private string _description;
    
        [DataMember]
        public Nullable<int> Minimum
        {
            get { return _minimum; }
            set
            {
                if (_minimum != value)
                {
                    _minimum = value;
                    OnPropertyChanged("Minimum");
                }
            }
        }
        private Nullable<int> _minimum;
    
        [DataMember]
        public System.DateTime Creation
        {
            get { return _creation; }
            set
            {
                if (_creation != value)
                {
                    _creation = value;
                    OnPropertyChanged("Creation");
                }
            }
        }
        private System.DateTime _creation;
    
        [DataMember]
        public decimal Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged("Price");
                }
            }
        }
        private decimal _price;
    
        [DataMember]
        public string ImageURL
        {
            get { return _imageURL; }
            set
            {
                if (_imageURL != value)
                {
                    _imageURL = value;
                    OnPropertyChanged("ImageURL");
                }
            }
        }
        private string _imageURL;

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public TrackableCollection<DetailPurchase> Purchases
        {
            get
            {
                if (_purchases == null)
                {
                    _purchases = new TrackableCollection<DetailPurchase>();
                    _purchases.CollectionChanged += FixupPurchases;
                }
                return _purchases;
            }
            set
            {
                if (!ReferenceEquals(_purchases, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_purchases != null)
                    {
                        _purchases.CollectionChanged -= FixupPurchases;
                        // This is the principal end in an association that performs cascade deletes.
                        // Remove the cascade delete event handler for any entities in the current collection.
                        foreach (DetailPurchase item in _purchases)
                        {
                            ChangeTracker.ObjectStateChanging -= item.HandleCascadeDelete;
                        }
                    }
                    _purchases = value;
                    if (_purchases != null)
                    {
                        _purchases.CollectionChanged += FixupPurchases;
                        // This is the principal end in an association that performs cascade deletes.
                        // Add the cascade delete event handler for any entities that are already in the new collection.
                        foreach (DetailPurchase item in _purchases)
                        {
                            ChangeTracker.ObjectStateChanging += item.HandleCascadeDelete;
                        }
                    }
                    OnNavigationPropertyChanged("Purchases");
                }
            }
        }
        private TrackableCollection<DetailPurchase> _purchases;
    
        [DataMember]
        public TrackableCollection<DetailSale> Sales
        {
            get
            {
                if (_sales == null)
                {
                    _sales = new TrackableCollection<DetailSale>();
                    _sales.CollectionChanged += FixupSales;
                }
                return _sales;
            }
            set
            {
                if (!ReferenceEquals(_sales, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_sales != null)
                    {
                        _sales.CollectionChanged -= FixupSales;
                        // This is the principal end in an association that performs cascade deletes.
                        // Remove the cascade delete event handler for any entities in the current collection.
                        foreach (DetailSale item in _sales)
                        {
                            ChangeTracker.ObjectStateChanging -= item.HandleCascadeDelete;
                        }
                    }
                    _sales = value;
                    if (_sales != null)
                    {
                        _sales.CollectionChanged += FixupSales;
                        // This is the principal end in an association that performs cascade deletes.
                        // Add the cascade delete event handler for any entities that are already in the new collection.
                        foreach (DetailSale item in _sales)
                        {
                            ChangeTracker.ObjectStateChanging += item.HandleCascadeDelete;
                        }
                    }
                    OnNavigationPropertyChanged("Sales");
                }
            }
        }
        private TrackableCollection<DetailSale> _sales;
    
        [DataMember]
        public TrackableCollection<CartItem> CartItems
        {
            get
            {
                if (_cartItems == null)
                {
                    _cartItems = new TrackableCollection<CartItem>();
                    _cartItems.CollectionChanged += FixupCartItems;
                }
                return _cartItems;
            }
            set
            {
                if (!ReferenceEquals(_cartItems, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_cartItems != null)
                    {
                        _cartItems.CollectionChanged -= FixupCartItems;
                    }
                    _cartItems = value;
                    if (_cartItems != null)
                    {
                        _cartItems.CollectionChanged += FixupCartItems;
                    }
                    OnNavigationPropertyChanged("CartItems");
                }
            }
        }
        private TrackableCollection<CartItem> _cartItems;

        #endregion
        #region ChangeTracking
    
        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        protected virtual void OnNavigationPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged{ add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
        private ObjectChangeTracker _changeTracker;
    
        [DataMember]
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
                return _changeTracker;
            }
            set
            {
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging -= HandleObjectStateChanging;
                }
                _changeTracker = value;
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
            }
        }
    
        private void HandleObjectStateChanging(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                ClearNavigationProperties();
            }
        }
    
        protected bool IsDeserializing { get; private set; }
    
        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext context)
        {
            IsDeserializing = true;
        }
    
        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            IsDeserializing = false;
            ChangeTracker.ChangeTrackingEnabled = true;
        }
    
        protected virtual void ClearNavigationProperties()
        {
            Purchases.Clear();
            Sales.Clear();
            CartItems.Clear();
        }

        #endregion
        #region Association Fixup
    
        private void FixupPurchases(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (DetailPurchase item in e.NewItems)
                {
                    item.Product = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("Purchases", item);
                    }
                    // This is the principal end in an association that performs cascade deletes.
                    // Update the event listener to refer to the new dependent.
                    ChangeTracker.ObjectStateChanging += item.HandleCascadeDelete;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (DetailPurchase item in e.OldItems)
                {
                    if (ReferenceEquals(item.Product, this))
                    {
                        item.Product = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Purchases", item);
                        // Delete the dependent end of this identifying association. If the current state is Added,
                        // allow the relationship to be changed without causing the dependent to be deleted.
                        if (item.ChangeTracker.State != ObjectState.Added)
                        {
                            item.MarkAsDeleted();
                        }
                    }
                    // This is the principal end in an association that performs cascade deletes.
                    // Remove the previous dependent from the event listener.
                    ChangeTracker.ObjectStateChanging -= item.HandleCascadeDelete;
                }
            }
        }
    
        private void FixupSales(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (DetailSale item in e.NewItems)
                {
                    item.Product = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("Sales", item);
                    }
                    // This is the principal end in an association that performs cascade deletes.
                    // Update the event listener to refer to the new dependent.
                    ChangeTracker.ObjectStateChanging += item.HandleCascadeDelete;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (DetailSale item in e.OldItems)
                {
                    if (ReferenceEquals(item.Product, this))
                    {
                        item.Product = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Sales", item);
                        // Delete the dependent end of this identifying association. If the current state is Added,
                        // allow the relationship to be changed without causing the dependent to be deleted.
                        if (item.ChangeTracker.State != ObjectState.Added)
                        {
                            item.MarkAsDeleted();
                        }
                    }
                    // This is the principal end in an association that performs cascade deletes.
                    // Remove the previous dependent from the event listener.
                    ChangeTracker.ObjectStateChanging -= item.HandleCascadeDelete;
                }
            }
        }
    
        private void FixupCartItems(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (CartItem item in e.NewItems)
                {
                    item.Product = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("CartItems", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (CartItem item in e.OldItems)
                {
                    if (ReferenceEquals(item.Product, this))
                    {
                        item.Product = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("CartItems", item);
                    }
                }
            }
        }

        #endregion
    }
}
