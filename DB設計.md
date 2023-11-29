# DB設計

## t_books テーブル
| Column | Type | Option |
| - | - | - |
| *book_id | nvarchar(16) | null:false |
| book_name | nvarchar(32) | null:false |
| buyDate | datetime | |
| link | text | |

#### Association
- has_many :t_bookmarks, dependent: :destroy


## t_bookmarks テーブル
| Column | Type | Option |
| - | - | - |
| *book_id | nvarchar(16) | null:false, foreign_key: true |
| *page | smallint | null:false |
| comment | text  |  |

#### Association
- belongs_to :t_books