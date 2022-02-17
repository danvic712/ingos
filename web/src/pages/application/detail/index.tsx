import { PageContainer } from '@ant-design/pro-layout';
import { Button } from 'antd';
import { useParams } from 'umi';

const Detail = () => {
  const { appName } = useParams();

  return (
    <PageContainer
      title={appName}
      onBack={() => window.history.back()}
      extra={[
        <Button key="3">Operation</Button>,
        <Button key="2">Operation</Button>,
        <Button key="1" type="primary">
          Primary
        </Button>,
      ]}
    />
  );
};

export default Detail;
