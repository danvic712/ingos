import {
  EditOutlined,
  EllipsisOutlined,
  FilterOutlined,
  PlusOutlined,
  SettingOutlined,
} from '@ant-design/icons';
import { Button, Card, List, message, Typography } from 'antd';
import { PageContainer } from '@ant-design/pro-layout';
import { useRequest, history } from 'umi';
import { queryFakeList } from './service';
import type { CardListItemDataType, LabelItemDataType } from './data.d';
import styles from './style.less';
import type { ProFormInstance } from '@ant-design/pro-form';
import { ProFormTextArea } from '@ant-design/pro-form';
import { DrawerForm, ProFormText } from '@ant-design/pro-form';
import ProForm, { LightFilter, ProFormDatePicker, ProFormSelect } from '@ant-design/pro-form';
import { useRef, useState } from 'react';
import type { ProColumns } from '@ant-design/pro-table';
import { EditableProTable } from '@ant-design/pro-table';

const { Paragraph } = Typography;

const Overview = () => {
  const { data, loading } = useRequest(() => {
    return queryFakeList({
      count: 32,
    });
  });

  const list = data?.list || [];

  const [drawerVisit, setDrawerVisit] = useState(false);

  const formRef = useRef<ProFormInstance>();

  const [editableKeys, setEditableRowKeys] = useState<React.Key[]>();
  const columns: ProColumns<LabelItemDataType>[] = [
    {
      title: 'Key',
      dataIndex: 'key',
      width: '40%',
    },
    {
      title: 'Value',
      dataIndex: 'value',
      width: '40%',
    },
    {
      title: '操作',
      valueType: 'option',
    },
  ];

  const content = (
    <div className={styles.pageHeaderContent}>
      <p>
        应用是一组服务的集合，通常，一个应用会包含多个服务，你可以通过此页面对通过平台部署在当前 K8s
        集群中的所有应用进行管理。
        你可以以针对每个应用进行启用/暂停、查看每个应用及其包含的服务的配置，运行中的日志信息，针对不同的应用，设置其所能使用集群资源（CPU、内存...）
      </p>
      <div className={styles.contentLink}>
        <LightFilter
          bordered
          collapseLabel={<FilterOutlined />}
          onFinish={async (values) => console.log(values)}
        >
          <ProFormText name="name" label="应用名称" />
          <ProFormText name="code" label="应用代码" />
          <ProFormSelect
            name="stateType"
            mode="tags"
            valueEnum={{
              created: '已创建',
              active: '运行中',
              offline: '已下线',
            }}
            placeholder="应用状态"
          />
          <ProFormDatePicker name="time" placeholder="创建日期" />
          <Button
            type="primary"
            onClick={() => {
              setDrawerVisit(true);
            }}
          >
            <PlusOutlined />
            新建应用
          </Button>
        </LightFilter>

        <DrawerForm
          onVisibleChange={setDrawerVisit}
          formRef={formRef}
          title="新建应用"
          width={400}
          visible={drawerVisit}
          submitter={{
            searchConfig: {
              resetText: '重置',
            },
            resetButtonProps: {
              onClick: () => {
                formRef.current?.resetFields();
              },
            },
          }}
          onFinish={async () => {
            message.success('提交成功');
            return true;
          }}
        >
          <ProForm.Group>
            <ProFormText
              width="sm"
              name="applicationName"
              label="应用名称"
              tooltip="最长为 24 位"
              required={true}
            />

            <ProFormText
              name="applicationCode"
              width="xs"
              label="应用代码"
              tooltip="应用代码会作为 K8s 中的 Namespace 名称"
              required={true}
            />
          </ProForm.Group>
          <ProForm.Item label="标签" name="dataSource" trigger="onValuesChange">
            <EditableProTable<LabelItemDataType>
              rowKey="id"
              toolBarRender={false}
              columns={columns}
              recordCreatorProps={{
                newRecordType: 'dataSource',
                position: 'bottom',
                record: () => ({
                  id: Date.now(),
                }),
              }}
              editable={{
                type: 'multiple',
                editableKeys,
                onChange: setEditableRowKeys,
                actionRender: (row, _, dom) => {
                  return [dom.delete];
                },
              }}
            />
          </ProForm.Item>
          <ProFormText name="url" label="应用地址" />
          <ProForm.Group />
          <ProFormTextArea name="description" label="描述" />
        </DrawerForm>
      </div>
    </div>
  );

  const extraContent = (
    <div className={styles.extraImg}>
      <img src="https://gw.alipayobjects.com/zos/rmsportal/RzwpdLnhmvDJToTdfDPe.png" />
    </div>
  );

  return (
    <PageContainer content={content} extraContent={extraContent}>
      <div className={styles.cardList}>
        <List<Partial<CardListItemDataType>>
          rowKey="id"
          loading={loading}
          grid={{
            gutter: 16,
            xs: 1,
            sm: 2,
            md: 3,
            lg: 3,
            xl: 4,
            xxl: 4,
          }}
          pagination={{
            defaultPageSize: 16,
            showSizeChanger: true,
            pageSizeOptions: ['16', '24', '48', '96'],
          }}
          dataSource={[...list]}
          renderItem={(item) => {
            if (!item || !item.id) {
              return false;
            }

            return (
              <List.Item key={item.id}>
                <Card
                  hoverable
                  className={styles.card}
                  actions={[
                    <EditOutlined key="edit" />,
                    <SettingOutlined key="setting" />,
                    <EllipsisOutlined key="ellipsis" />,
                  ]}
                  onClick={() => {
                    history.push(`/applications/${item.title}/details`);
                  }}
                >
                  <Card.Meta
                    avatar={<img alt="" className={styles.cardAvatar} src={item.avatar} />}
                    title={<a>{item.title}</a>}
                    description={
                      <Paragraph className={styles.item} ellipsis={{ rows: 3 }}>
                        {item.description}
                      </Paragraph>
                    }
                  />
                </Card>
              </List.Item>
            );
          }}
        />
      </div>
    </PageContainer>
  );
};

export default Overview;
