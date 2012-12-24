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
    [KnownType(typeof(Product))]
    public partial class CartItem: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int CartItemID
        {
            get { return _cartItemID; }
            set
            {
                if (_cartItemID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'CartItemID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _cartItemID = value;
                    OnPropertyChanged("CartItemID");
                }
            }
        }
        private int _cartItemID;
    
        [DataMember]
        public int ProductID
        {
            get { return _productID; }
            set
            {
                if (_productID != value)
                {
                    ChangeTracker.RecordOriginalValue("ProductID", _productID);
                    if (!IsDeserializing)
                    {
                        if (Product != null && Product.ProductID != value)
                        {
                            Product = null;
                        }
                    }
                    _productID = value;
                    OnPropertyChanged("ProductID");
                }
            }
        }
        private int _productID;
    
        [DataMember]
        public string CartID
        {
            get { return _cartID; }
            set
            {
                if (_cartID != value)
                {
                    _cartID = value;
                    OnPropertyChanged("CartID");
                }
            }
        }
        private string _cartID;
    
        [DataMember]
        public int Amount
        {
            get { return _amount; }
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                    OnPropertyChanged("Amount");
                }
            }
        }
        private int _amount;
    
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

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public Product Product
        {
            get { return _product; }
            set
            {
                if (!ReferenceEquals(_product, value))
                {
                    var previousValue = _product;
                    _product = value;
                    FixupProduct(previousValue);
                    OnNavigationPropertyChanged("Product");
                }
            }
        }
        private Product _product;

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
            Product = null;
        }

        #endregion
        #region Association Fixup
    
        private void FixupProduct(Product previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.CartItems.Contains(this))
            {
                previousValue.CartItems.Remove(this);
            }
    
            if (Product != null)
            {
                if (!Product.CartItems.Contains(this))
                {
                    Product.CartItems.Add(this);
                }
    
                ProductID = Product.ProductID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Product")
                    && (ChangeTracker.OriginalValues["Product"] == Product))
                {
                    ChangeTracker.OriginalValues.Remove("Product");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Product", previousValue);
                }
                if (Product != null && !Product.ChangeTracker.ChangeTrackingEnabled)
                {
                    Product.StartTracking();
                }
            }
        }

        #endregion
    }
}
